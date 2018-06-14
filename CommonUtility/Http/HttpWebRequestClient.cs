using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace CommonUtility.Http
{
    public class HttpWebRequestClient
    {
        private readonly HttpWebRequest _client;
        private readonly MemoryStream _postStream = new MemoryStream();

        private HttpWebRequestClient(string url)
        {
            _client = WebRequest.Create(url) as HttpWebRequest;
            _client.CookieContainer = new CookieContainer();
            _client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:60.0) Gecko/20100101 Firefox/60.0";
            _client.AllowAutoRedirect = true;
        }

        public static HttpWebRequestClient Create(string url)
        {
            return new HttpWebRequestClient(url);
        }

        public HttpWebRequestClient WithProxy(IWebProxy webProxy)
        {
            _client.Proxy = webProxy;

            return this;
        }

        public HttpWebRequestClient WithCookies(CookieContainer cookieContainer)
        {
            _client.CookieContainer = cookieContainer;

            return this;
        }

        public HttpWebRequestClient AutoRedirect(bool allowAutoRedirect)
        {
            _client.AllowAutoRedirect = allowAutoRedirect;

            return this;
        }

        public HttpWebRequestClient WithParamters(IEnumerable<KeyValuePair<string, string>> parameters)
        {
            return WithParamters(parameters, Encoding.UTF8);
        }

        public HttpWebRequestClient WithParamters(IEnumerable<KeyValuePair<string, string>> parameters,
            Encoding encoding)
        {
            CachePostData(parameters, _postStream);

            return this;
        }

        private async void CachePostData(IEnumerable<KeyValuePair<string, string>> parameters, MemoryStream postStream)
        {
            using (var content = new FormUrlEncodedContent(parameters))
            {
                await content.CopyToAsync(postStream);
            }
        }

        private void DoPostData()
        {
            if (_postStream.Length > 0)
            {
                _client.Method = "POST";
                _client.ContentType = "application/x-www-form-urlencoded";
                _client.ContentLength = _postStream.Length;

                _postStream.Position = 0;

                _client.ContentLength = _postStream.Length;
                using (var req = _client.GetRequestStream())
                {
                    _postStream.CopyTo(req);
                }
            }
        }

        public Stream GetResponseStream()
        {
            DoPostData();

            var response = _client.GetResponse() as HttpWebResponse;
            _client.CookieContainer.Add(response.Cookies);

            return response.GetResponseStream();
        }

        public string GetResponseString()
        {
            return GetResponseString(Encoding.UTF8);
        }

        public string GetResponseString(Encoding encoding)
        {
            using (var response = GetResponseStream())
            using (var reader = new StreamReader(response, encoding))
            {
                return reader.ReadToEnd();
            }
        }
    }
}