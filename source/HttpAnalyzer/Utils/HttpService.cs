using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Http;

using HttpAnalyzer.Models.Data;

namespace HttpAnalyzer.Utils
{
    internal class HttpService : IDisposable
    {
        #region Implementation Singleton

        private static object _sync = new object();

        private static HttpService _instance;

        public static HttpService Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_sync)
                    {
                        if (_instance == null)
                        {
                            _instance = new HttpService();
                        }
                    }
                }

                return _instance;
            }
        }

        #endregion

        private HttpClient _client;

        private HttpService()
        {
            _client = new HttpClient();
        }

        public async Task SendAsync(HttpRequest model, Action<HttpResponse> success, Action<Exception> error)
        {
            try
            {
                using (var request = BuildRequest(model))
                {
                    var timer = new Stopwatch();

                    timer.Start();

                    var response = await _client.SendAsync(request);

                    timer.Stop();

                    success?.Invoke(await BuildResponse(response, timer.Elapsed));
                }
            }
            catch (Exception e)
            {
                error?.Invoke(e);
            }
        }

        private HttpRequestMessage BuildRequest(HttpRequest model)
        {
            var request = new HttpRequestMessage(model.Method, model.Uri);

            return request;
        }

        private async Task<HttpResponse> BuildResponse(HttpResponseMessage model, TimeSpan requestTime)
        {
            using (model)
            {
                var body = await TryReadContent(model.Content);
                var size = model.Content.Headers.ContentLength;
                var response = new HttpResponse
                {
                    StatusCode = (int)model.StatusCode,
                    RequestTime = requestTime,
                    Size = size.HasValue ? size.Value : 0,
                    Body = body
                };

                return response;
            }
        }

        private async Task<string> TryReadContent(HttpContent content)
        {
            try
            {
                return await content.ReadAsStringAsync();
            }
            catch
            {
                return string.Empty;
            }
        }

        #region Implementation IDisposable

        public void Dispose()
        {
            _client.Dispose();
            _client = null;
            _instance = null;
        }

        #endregion
    }
}