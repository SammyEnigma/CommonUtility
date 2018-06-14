using System;
using System.Configuration;
using System.Reflection;
using CommonUtility.Convert;
using CommonUtility.Logging;

namespace CommonUtility.Config
{
    public class Configurator
    {
        private static readonly Logger Logger = new Logger(MethodBase.GetCurrentMethod().DeclaringType);

        public static T GetConfiguration<T>(string key, T defaultValue)
        {
            return GetConfiguration(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None), key,
                defaultValue);
        }

        public static T GetConfiguration<T>(Configuration configuration, string key, T defaultValue)
        {
            var result = defaultValue;
            try
            {
                var value = configuration.AppSettings.Settings[key].Value;
                result = Converter.TryParse(value, defaultValue);
            }
            catch (Exception ex)
            {
                Logger.Error("Get {0} configuration failed & use default value {1}, error {2}", key, defaultValue, ex);
            }

            return result;
        }

        public static void SetConfiguration(string key, string value)
        {
            SetConfiguration(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None), key, value);
        }

        public static void SetConfiguration(Configuration configuration, string key, string value)
        {
            try
            {
                configuration.AppSettings.Settings.Remove(key);
                configuration.AppSettings.Settings.Add(key, value);
                configuration.Save(ConfigurationSaveMode.Minimal);
            }
            catch (Exception ex)
            {
                Logger.Error("Set {0} configuration with {1} failed, error {2}", key, value, ex);
            }
        }
    }
}