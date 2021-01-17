using HttpAnalyzer.Base;

namespace HttpAnalyzer.Models.View
{
    internal abstract class BaseResponsePanelViewModel : BindableObject
    {
        public const string RESPONSE_DESCRIPTION = "Response";

        public const string HEADERS_DESCRIPTION = "Headers";

        public const string COOKIES_DESCRIPTION = "Cookies";

        public const string BODY_DESCRIPTION = "Body";

        private bool _isHeadersVisible;

        private bool _isCookiesVisible;

        private bool _isBodyVisible;

        public bool IsHeadersVisible
        {
            get => _isHeadersVisible;
            set => SetValue(ref _isHeadersVisible, value);
        }

        public bool IsCookiesVisible
        {
            get => _isCookiesVisible;
            set => SetValue(ref _isCookiesVisible, value);
        }

        public bool IsBodyVisible
        {
            get => _isBodyVisible;
            set => SetValue(ref _isBodyVisible, value);
        }
    }
}
