using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PinnacleWrapper.Exceptions {
    public static class HttpResponseMessageExtensions {
        public static async Task EnsureSuccessStatusCodeCustomAsync(this HttpResponseMessage response) {
            if (response.IsSuccessStatusCode) {
                return;
            }

            var content = await response.Content.ReadAsStringAsync();

            if (response.Content != null)
                response.Content.Dispose();
            throw new SimpleHttpResponseException(response.StatusCode, content);
        }
        public static void EnsureSuccessStatusCodeCustom(this HttpResponseMessage response) {

            if (response.IsSuccessStatusCode) {
                return;
            }
            var content = response.Content.ReadAsStringAsync().Result;

            if (response.Content != null)
                response.Content.Dispose();

            throw new SimpleHttpResponseException(response.StatusCode, content);

        }
    }

    public class SimpleHttpResponseException : Exception {
        public HttpStatusCode StatusCode { get; private set; }

        public SimpleHttpResponseException(HttpStatusCode statusCode, string content) : base(content) {
            StatusCode = statusCode;
        }
    }
}
