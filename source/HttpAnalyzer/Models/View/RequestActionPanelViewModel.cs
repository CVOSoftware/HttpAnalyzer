using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HttpAnalyzer.Base;
using HttpAnalyzer.Utils.Helpers;

namespace HttpAnalyzer.Models.View
{
    internal class RequestActionPanelViewModel : BindableObject
    {
        private const string SEND_LABEL = "Send";

        private const string STOP_LABEL = "Stop";

        private bool _isEditableState;

        private bool _isUrlEmpty;

        private string _url;

        private string _sendLabel;

        private string _selectedHttpMethod;

        private RelayCommand _sendRequestCmd;

        private RelayCommand _clearUrlCmd;

        public RequestActionPanelViewModel()
        {
            _isEditableState = true;
            _url = string.Empty;
            _sendLabel = SEND_LABEL;
            _selectedHttpMethod = HttpMethodHelper.GET;
            HttpMethods = HttpMethodHelper.GetAll;
        }

        public bool IsEditableState
        {
            get => _isEditableState;
            set => SetValue(ref _isEditableState, value);
        }

        public bool IsUrlEmpty
        {
            get => _isUrlEmpty;
            set => SetValue(ref _isUrlEmpty, value);
        }


        public string SendLabel
        {
            get => _sendLabel;
            set => SetValue(ref _sendLabel, value);
        }

        public string Url
        {
            get => _url;
            set
            {
                if(SetValue(ref _url, value))
                {
                    IsUrlEmpty = string.IsNullOrEmpty(value) == false && value.Length > 0;
                }
            }
        }

        public string SelectedHttpMethod
        {
            get => _selectedHttpMethod;
            set => SetValue(ref _selectedHttpMethod, value);
        }

        public string[] HttpMethods { get; }

        public RelayCommand SendRequestCommand => RelayCommand.Register(ref _sendRequestCmd, OnSendRequest, CanSendRequest);

        public RelayCommand ClearUrlCmd => RelayCommand.Register(ref _clearUrlCmd, OnClearUrl);

        private void OnSendRequest(object obj)
        {
            IsEditableState = !_isEditableState;
            SendLabel = _isEditableState ? SEND_LABEL : STOP_LABEL;
        }

        private void OnClearUrl(object obj)
        {
            Url = string.Empty;
        }

        private bool CanSendRequest(object obj)
        {
            return string.IsNullOrEmpty(_url) == false
                && string.IsNullOrWhiteSpace(_url) == false
                && _selectedHttpMethod != null;
        }
    }
}
