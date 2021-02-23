using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace HttpAnalyzer.Models.Data
{
    internal class HttpRequest
    {
        public Uri Uri { get; set; }

        public HttpMethod Method { get; set; }

        public Dictionary<string, string> Headers { get; set; }

        public string Body { get; set; }
    }
}
