using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HttpAnalyzer.Base;
using HttpAnalyzer.Models.Contract;
using HttpAnalyzer.Models.Data;
using HttpAnalyzer.Utils;
using HttpAnalyzer.Utils.Helpers;

namespace HttpAnalyzer.Models.View
{
    internal class RequestActionPanelViewModel : BindableObject, IDataSubscriber<ActionPanelModel>
    {
        private const string SEND_LABEL = "Send";

        private const string STOP_LABEL = "Stop";

        private bool _canUpdate;

        private bool _isEditableState;

        private bool _clearButtonVisibility;

        private string _url;

        private string _sendLabel;

        private string _selectedHttpMethod;

        private RelayCommand _sendRequestCmd;

        private RelayCommand _clearUrlCmd;

        public RequestActionPanelViewModel()
        {
            ModelHub.Instance.Subscribe<RequestActionPanelViewModel, ActionPanelModel>(this);

            _sendLabel = SEND_LABEL;
            HttpMethods = HttpMethodHelper.GetAll;
        }

        public bool IsEditableState
        {
            get => _isEditableState;
            set
            {
                if(SetValue(ref _isEditableState, value) && _canUpdate)
                {
                    UpdateModel();
                }
            }
        }

        public bool ClearButtonVisibility
        {
            get => _clearButtonVisibility;
            set => SetValue(ref _clearButtonVisibility, value);
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
                    ClearButtonVisibility = string.IsNullOrEmpty(value) == false && value.Length > 0;

                    if(_canUpdate)
                    {
                        UpdateModel();
                    }
                }
            }
        }

        public string SelectedHttpMethod
        {
            get => _selectedHttpMethod;
            set 
            {
                if(SetValue(ref _selectedHttpMethod, value) && _canUpdate)
                {
                    UpdateModel();
                }
            }
        }

        public string[] HttpMethods { get; }

        public RelayCommand SendRequestCommand => RelayCommand.Register(ref _sendRequestCmd, OnSendRequest, CanSendRequest);

        public RelayCommand ClearUrlCmd => RelayCommand.Register(ref _clearUrlCmd, OnClearUrl);

        private void OnSendRequest(object obj)
        {
            IsEditableState = !_isEditableState;

            if(_isEditableState)
            {
                SendLabel = SEND_LABEL;
                ClearButtonVisibility = string.IsNullOrEmpty(_url) == false && _url.Length > 0;
            }
            else
            {
                SendLabel = STOP_LABEL;
                ClearButtonVisibility = false;

                var request = BuildRequest();

                Task.Run(async () => await HttpService.Instance.SendAsync(request, Success, Error));
            }
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

        private void UpdateModel()
        {
            var model = new ActionPanelModel
            {
                EditableState = _isEditableState,
                Url = _url,
                HttpMethod = _selectedHttpMethod
            };

            ModelHub.Instance.UpdateWithIgnore(this, model);
        }

        private void UnlockAfterResponse()
        {
            IsEditableState = !_isEditableState;
            SendLabel = SEND_LABEL;
            ClearButtonVisibility = string.IsNullOrEmpty(_url) == false && _url.Length > 0;
        }

        private void UpdateModelHubAfterRequest(HttpResponse model)
        {
            var statusPanelModel = new StatusPanelModel
            {
                StatusCode = model.StatusCode,
                RequestTime = model.RequestTime,
                Size = model.Size,
            };

            ModelHub.Instance.Update<ResponseStatusPanelViewModel, StatusPanelModel>(statusPanelModel);
        }

        private HttpRequest BuildRequest()
        {
            var request = new HttpRequest
            {
                Uri = new UriBuilder(_url).Uri,
                Method = HttpMethodHelper.Get(_selectedHttpMethod)
            };

            return request;
        }

        #region Implementation IDataSubscriber<ActionPanelModel>

        public void IsNewNotification(ActionPanelModel model)
        {
            IsEditableState = model.EditableState;
            Url = model.Url;
            SelectedHttpMethod = model.HttpMethod;
            _canUpdate = true;
        }

        public void IsUpdateNotification(ActionPanelModel model)
        {
            IsNewNotification(model);
        }

        #endregion

        #region Http request handlers

        private void Success(HttpResponse model)
        {
            UnlockAfterResponse();
            UpdateModelHubAfterRequest(model);
        }

        private void Error(Exception model)
        {
            UnlockAfterResponse();
        }

        #endregion
    }
}
