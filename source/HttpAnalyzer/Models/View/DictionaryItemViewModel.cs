using HttpAnalyzer.Base;

namespace HttpAnalyzer.Models.View
{
    internal class DictionaryItemViewModel : BindableObject
    {
        private bool _isChecked;

        private string _key;

        private string _value;

        public DictionaryItemViewModel(string key, string value)
        {
            _key = key;
            _value = value;
        }

        public bool IsChecked
        {
            get => _isChecked;
            set => SetValue(ref _isChecked, value);
        }

        public string Key
        {
            get => _key;
            set => SetValue(ref _key, value);
        }

        public string Value
        {
            get => _value;
            set => SetValue(ref _value, value);
        }
    }
}
