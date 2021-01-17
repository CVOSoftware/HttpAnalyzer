namespace HttpAnalyzer.Models.View
{
    internal abstract class BaseRequestPanelViewModel : BaseResponsePanelViewModel
    {
        public string REQUEST_DESCRIPTION = "Request";

        public const string PARAMS_DESCRIPTION = "Params";

        public const string AUTHORIZATION_DESCRIPTION = "Authorization";

        private bool _isParamsVisible;

        private bool _isAuthorizationVisible;

        public bool IsParamsVisible
        {
            get => _isParamsVisible;
            set => SetValue(ref _isParamsVisible, value);
        }

        public bool IsAuthorizationVisible
        {
            get => _isAuthorizationVisible;
            set => SetValue(ref _isAuthorizationVisible, value);
        }
    }
}
