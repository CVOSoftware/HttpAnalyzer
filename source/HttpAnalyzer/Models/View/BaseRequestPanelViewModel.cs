namespace HttpAnalyzer.Models.View
{
    internal abstract class BaseRequestPanelViewModel : BaseResponsePanelViewModel
    {
        private const string PARAMS_LABEL = "Params";

        private const string AUTHORIZATION_LABEL = "Authorization";

        public string ParamsLabel => PARAMS_LABEL;

        public string AuthorizationLabel => AUTHORIZATION_LABEL;
    }
}
