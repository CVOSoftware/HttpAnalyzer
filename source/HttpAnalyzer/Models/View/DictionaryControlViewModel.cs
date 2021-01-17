using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

using HttpAnalyzer.Base;
using HttpAnalyzer.Models.Data;

namespace HttpAnalyzer.Models.View
{
    internal class DictionaryControlViewModel : BindableObject
    {
        public const string KEY_DESCRIPTION = "Key";

        public const string VALUE_DESCRIPTION = "Value";


        public DictionaryControlViewModel()
        {
            Collection = new ObservableCollection<DictionaryItemViewModel>();
        }

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
