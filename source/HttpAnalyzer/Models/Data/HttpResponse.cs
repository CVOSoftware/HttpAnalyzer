using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpAnalyzer.Models.Data
{
    internal class HttpResponse
    {
        public int StatusCode { get; set; }

        public TimeSpan RequestTime { get; set; }

        public long Size { get; set; }

        public string Body { get; set; }
    }
}
