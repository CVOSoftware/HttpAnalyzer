using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HttpAnalyzer.Base;

namespace HttpAnalyzer.Models.View
{
    internal class ResponseStatusPanelViewModel : BindableObject
    {
        private const string STATUS_LABEL = "Status";

        private const string TIME_LABEL = "Time";

        private const string SIZE_LABEL = "Size";

        private const string SAVE_RESPONSE_LABEL = "Save response";

        private RelayCommand _saveResponseCmd;

        public ResponseStatusPanelViewModel()
        {

        }

        public string StatusLabel => STATUS_LABEL;

        public string TimeLabel => TIME_LABEL;

        public string SizeLabel => SIZE_LABEL;

        public string SaveResponseLabel => SAVE_RESPONSE_LABEL;

        public RelayCommand SaveResponseCmd => RelayCommand.Register(ref _saveResponseCmd, OnSaveResponse, CanSaveResponse);

        public void OnSaveResponse(object obj)
        {

        }

        public bool CanSaveResponse(object o)
        {
            return default;
        }
    }
}
