using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HttpAnalyzer.Base;

namespace HttpAnalyzer.Models.View
{
    internal class RequestPanelViewModel : BaseRequestPanelViewModel
    {
        private const string REQUEST_LABEL = "Request";

        public RequestPanelViewModel()
        {
            ParamsDictionaryVM = new DictionaryControlViewModel();
            HeadersDictionaryVM = new DictionaryControlViewModel();
        }

        public string RequestLabel => REQUEST_LABEL;

        public DictionaryControlViewModel ParamsDictionaryVM { get; }

        public DictionaryControlViewModel HeadersDictionaryVM { get; }
    }
}
