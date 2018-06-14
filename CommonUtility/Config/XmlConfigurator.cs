using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Xml;
using CommonUtility.Logging;

namespace CommonUtility.Config
{
    public class XmlConfigurator : IDisposable
    {
        private const int TimeoutMillsecond = 500;
        private static readonly Logger Logger = new Logger(MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly Dictionary<string, XmlConfigurator> Configurators =
            new Dictionary<string, XmlConfigurator>();

        private readonly FileInfo _configFile;
        private readonly Timer _timer;
        private readonly FileSystemWatcher _watcher;

        private readonly IXmlConfig _xmlConfigEntity;

        private XmlConfigurator(IXmlConfig configEntity, FileInfo configFile)
        {
            _configFile = configFile;
            _xmlConfigEntity = configEntity;

            _watcher = new FileSystemWatcher
            {
                Path = _configFile.DirectoryName,
                Filter = _configFile.Name,
                NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.LastWrite | NotifyFilters.FileName
            };

            _watcher.Changed += ConfigFileChangedHandler;
            _watcher.Created += ConfigFileChangedHandler;
            _watcher.Deleted += ConfigFileChangedHandler;
            _watcher.Renamed += ConfigFileRenamedHandler;

            _watcher.EnableRaisingEvents = true;

            _timer = new Timer(OnConfigFileChanged, null, Timeout.Infinite, Timeout.Infinite);
        }

        public void Dispose()
        {
            if (_watcher != null)
            {
                _watcher.EnableRaisingEvents = false;
                _watcher.Dispose();
            }

            _timer?.Dispose();
        }

        public static void ConfigAndWatch(IXmlConfig configEntity, FileInfo configFile)
        {
            Logger.Debug($"Config and watch file:{configFile}");

            if (configFile == null)
            {
                Logger.Debug($"Configure called with null 'configFile' parameter");
                return;
            }

            if (configEntity == null)
            {
                Logger.Debug($"Configure called with null 'configEntity' parameter");
                return;
            }

            InternalConfigure(configEntity, configFile);
            try
            {
                lock (Configurators)
                {
                    if (Configurators.TryGetValue(configFile.FullName, out var handler))
                    {
                        handler?.Dispose();
                    }

                    Configurators[configFile.FullName] = new XmlConfigurator(configEntity, configFile);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(
                    $"Failed to initialize configuration file watcher for the file:{configFile.FullName}, due to:{ex}");
            }
        }

        private void OnConfigFileChanged(object state)
        {
            InternalConfigure(_xmlConfigEntity, _configFile);
        }

        private static void InternalConfigure(IXmlConfig configEntity, FileInfo configFile)
        {
            if (configFile == null)
            {
                Logger.Debug($"Configure called with null 'configFile' parameter");
                return;
            }

            Logger.Debug($"Configuring file:{configFile.FullName}");

            if (File.Exists(configFile.FullName))
            {
                FileStream fileStream = null;
                for (var retry = 5; --retry >= 0;)
                    try
                    {
                        fileStream = configFile.Open(FileMode.Open, FileAccess.Read, FileShare.Read);
                        break;
                    }
                    catch (IOException ex)
                    {
                        if (retry == 0)
                        {
                            Logger.Error($"Failed to open XML config file:{configFile.FullName}, due to:{ex}");

                            // The stream cannot be valid
                            fileStream = null;
                        }

                        Thread.Sleep(250);
                    }

                if (fileStream == null) return;
                try
                {
                    // Load the configuration from the stream
                    InternalConfigure(configEntity, fileStream);
                }
                finally
                {
                    // Force the file closed whatever happens
                    fileStream.Close();
                }
            }
            else
            {
                Logger.Debug($"Config file {configFile.FullName} not found. Configuration unchanged.");
            }
        }

        private static void InternalConfigure(IXmlConfig configEntity, FileStream fileStream)
        {
            if (fileStream == null)
            {
                Logger.Debug($"Configure called with null 'fileStream' parameter");
                return;
            }

            if (configEntity == null)
            {
                Logger.Debug($"Configure called with null 'configEntity' parameter");
                return;
            }

            var xmlDoc = new XmlDocument();
            try
            {
                var settings = new XmlReaderSettings
                {
                    DtdProcessing = DtdProcessing.Parse
                };

                using (var xmlReader = XmlReader.Create(fileStream, settings))
                {
                    xmlDoc.Load(xmlReader);
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Error while loading XML configuration, due to:{ex}");
                xmlDoc = null;
            }

            if (xmlDoc != null)
            {
                Logger.Debug($"Loading XML configuration.");
                configEntity.Config(xmlDoc.DocumentElement);
            }
        }

        private void ConfigFileRenamedHandler(object sender, RenamedEventArgs e)
        {
            Logger.Debug(
                $"ConfigFileRenamedHandler, file path:{e.OldFullPath} => {e.FullPath}, file name:{e.OldName} => {e.Name}, change type:{e.ChangeType}");
            _timer.Change(TimeoutMillsecond, Timeout.Infinite);
        }

        private void ConfigFileChangedHandler(object sender, FileSystemEventArgs e)
        {
            Logger.Debug(
                $"ConfigFileChangedHandler, file path:{e.FullPath}, file name:{e.Name}, change type:{e.ChangeType}");
            _timer.Change(TimeoutMillsecond, Timeout.Infinite);
        }
    }
}