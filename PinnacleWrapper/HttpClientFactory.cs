using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace PinnacleWrapper
{
    public static class HttpClientFactory
    {
        public static HttpClient GetNewInstance(string clientId, string password, HttpClientHandler handler,
            string baseAddress = PinnacleClient.DefaultBaseAddress)
        {
            var httpClient = new HttpClient(handler);

            return GetNewInstance(clientId, password, baseAddress, httpClient);
        }

        public static HttpClient GetNewInstance(string clientId, string password, bool gzipCompression = true,
            string baseAddress = PinnacleClient.DefaultBaseAddress, WebProxy proxy = null)
        {
            var handler = new HttpClientHandler();

            if (gzipCompression)
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            if (proxy!=null) 
                handler.Proxy = proxy;

            var httpClient = new HttpClient(handler,true);

            return GetNewInstance(clientId, password, baseAddress, httpClient);
        }

        private static HttpClient GetNewInstance(string clientId, string password, string baseAddress,
            HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(baseAddress);

            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(Encoding.ASCII.GetBytes($"{clientId}:{password}")));

            return httpClient;
        }
    }
}