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

        private bool _isEditableState;

        private string _url;

        private string _selectedHttpMethod;

        private RelayCommand _sendRequestCmd;

        public RequestActionPanelViewModel()
        {
            _isEditableState = true;
            HttpMethods = HttpMethodHelper.GetAll;
        }

        public bool IsEditableState
        {
            get => _isEditableState;
            set => SetValue(ref _isEditableState, value);
        }

        public string SendLabel => SEND_LABEL;

        public string Url
        {
            get => _url;
            set => SetValue(ref _url, value);
        }

        public string SelectedHttpMethod
        {
            get => _selectedHttpMethod;
            set => SetValue(ref _selectedHttpMethod, value);
        }

        public string[] HttpMethods { get; }

        public RelayCommand SendRequestCommand => RelayCommand.Register(ref _sendRequestCmd, OnSendRequest, CanSendRequest);

        private void OnSendRequest(object obj)
        {
            IsEditableState = false;
        }

        private bool CanSendRequest(object o)
        {
            return string.IsNullOrEmpty(_url) == false
                && string.IsNullOrWhiteSpace(_url) == false
                && _selectedHttpMethod != null
                && _isEditableState;
        }
    }
}
