using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

using HttpAnalyzer.Base;
using HttpAnalyzer.Models.Data;

namespace HttpAnalyzer.Models.View
{
    internal class DictionaryControlViewModel : BindableObject
    {
        private const string KEY_LABEL = "Key";

        private const string VALUE_LABEL = "Value";

        public DictionaryControlViewModel()
        {
            Collection = new ObservableCollection<DictionaryItemViewModel>();
        }

        public string KeyLabel => KEY_LABEL;

        public string ValueLabel => VALUE_LABEL;

        public ObservableCollection<DictionaryItemViewModel> Collection { get; private set; }

        private void ClearCollection()
        {
            Collection.Clear();
        }

        private void UpdateCollection(List<DictionaryItem> collection)
        {
            var viewModels = collection.Select(item => new DictionaryItemViewModel(item.Key, item.Value));

            foreach(var viewModel in viewModels)
            {
                Collection.Add(viewModel);
            }
        }
    }
}
