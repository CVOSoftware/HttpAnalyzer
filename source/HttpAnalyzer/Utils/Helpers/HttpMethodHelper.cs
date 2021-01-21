using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace HttpAnalyzer.Utils.Helpers
{
    internal static class HttpMethodHelper
    {
        public const string GET = "GET";

        public const string POST = "POST";

        public const string PUT = "PUT";

        public const string DELETE = "DELETE";

        private static string[] _keys;

        private static Dictionary<string, Func<HttpMethod>> _collection;

        static HttpMethodHelper()
        {
            _collection = new Dictionary<string, Func<HttpMethod>>
            {
                { GET, () => HttpMethod.Get },
                { POST, () => HttpMethod.Post },
                { PUT, () => HttpMethod.Put },
                { DELETE, () => HttpMethod.Delete }
            };

            _keys = _collection.Keys.ToArray();
        }

        public static string[] GetAll => _keys;

        public static HttpMethod Get(string key)
        {
            if(_collection.TryGetValue(key, out var value))
            {
                return value.Invoke();
            }

            throw new NotSupportedException("Incorrect http method name");
        }
    }
}
