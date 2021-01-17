using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HttpAnalyzer.Base;

namespace HttpAnalyzer.Models.View
{
    internal class HttpAnalyzerWindowViewModel : BindableObject
    {
        public HttpAnalyzerWindowViewModel()
        {
            RequestActionPanelVM = new RequestActionPanelViewModel();
            RequestPanelVM = new RequestPanelViewModel();
            ResponsePanelVM = new ResponsePanelViewModel();
            ResponseStatusVM = new ResponseStatusPanelViewModel();
        }

        public RequestActionPanelViewModel RequestActionPanelVM { get; }

        public RequestPanelViewModel RequestPanelVM { get; }

        public ResponsePanelViewModel ResponsePanelVM { get; }

        public ResponseStatusPanelViewModel ResponseStatusVM { get; }
    }
}
