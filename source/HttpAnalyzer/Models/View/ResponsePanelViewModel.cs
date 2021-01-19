using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HttpAnalyzer.Base;

namespace HttpAnalyzer.Models.View
{
    internal class ResponsePanelViewModel : BaseResponsePanelViewModel
    {
        private const string RESPONSE_LABEL = "Response";

        public ResponsePanelViewModel()
        {

        }

        public string ResponseLabel => RESPONSE_LABEL;
    }
}
