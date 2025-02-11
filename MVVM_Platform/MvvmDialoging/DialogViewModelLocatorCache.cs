using Platform.Extensions.Enum;
using Platform.Extensions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmDialoging
{
    internal class DialogTypeLocatorCache
    {
        private readonly Dictionary<Type, Type> cache;

        public DialogTypeLocatorCache() => cache = new();

        internal void Add(Type viewModel,Type dialog)
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));
            if (dialog == null) throw new ArgumentNullException(nameof(dialog));
            if (cache.ContainsKey(viewModel))
                cache[viewModel] = dialog;
            else
                cache.Add(viewModel, dialog);
        }

        internal Type?Get(Type viewModelType)
        {
            if (viewModelType == null)
                throw new ArgumentNullException(nameof(viewModelType));
            cache.TryGetValue(viewModelType, out var dialog);
            return dialog;
        }
        internal void Clear() => cache.Clear();
        internal void Remove(Type viewModel)
        {
            if (cache.ContainsKey(viewModel))
                cache.Remove(viewModel);
        }
        internal int Count => cache.Count;
    }
    internal class DialogViewModelLocatorCache
    {
        private readonly Dictionary<IviewModel, iWindow> cache;

        public DialogViewModelLocatorCache() => cache = new();

        internal void TryAdd(IviewModel viewModel, iWindow dialog)
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));
            if (dialog == null) throw new ArgumentNullException(nameof(dialog));
            if (cache.ContainsKey(viewModel))
                cache[viewModel] = dialog;
            else
                cache.Add(viewModel, dialog);
        }

        internal iWindow? Get(IviewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));
            cache.TryGetValue(viewModel, out var dialog);
            return dialog;
        }
        internal void Clear() => cache.Clear();
        internal void Remove(IviewModel viewModel)
        {
            if (cache.ContainsKey(viewModel))
                cache.Remove(viewModel);
        }
        internal int Count => cache.Count;
    }

}
