using HttpAnalyzer.Base;

namespace HttpAnalyzer.Models.View
{
    internal abstract class BaseResponsePanelViewModel : BindableObject
    {
        private const string HEADERS_LABEL = "Headers";

        private const string COOKIES_LABEL = "Cookies";

        private const string BODY_LABEL = "Body";

        public string HeadersLabel => HEADERS_LABEL;

        public string CookiesLabel => COOKIES_LABEL;

        public string BodyLabel => BODY_LABEL;
    }
}
