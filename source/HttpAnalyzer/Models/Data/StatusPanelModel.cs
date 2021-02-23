using System;

namespace HttpAnalyzer.Models.Data
{
    internal class StatusPanelModel
    {
        public int StatusCode { get; set; }

        public TimeSpan RequestTime { get; set; }

        public long Size { get; set; }
    }
}