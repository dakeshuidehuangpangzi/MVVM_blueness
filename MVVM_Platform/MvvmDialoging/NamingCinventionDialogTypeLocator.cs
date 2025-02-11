
using Platform.Extensions.Enum;
using Platform.Extensions.Interfaces;
using System.Reflection;

namespace MvvmDialoging
{
    public class NamingCinventionDialogTypeLocator : IDialogTypeLocator
    {
        internal static readonly DialogTypeLocatorCache cache = new();
        public Type Locate(IviewModel viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));
            Type viewModelType = viewModel.GetType();
            Type? dialogType = cache.Get(viewModelType);
            if (dialogType != null) return dialogType;
            string dialogname = GetDialogName(viewModelType);
            dialogType = GetAssemblyFromType(viewModelType).GetType(dialogname);
            if (dialogType == null && viewModel is OtherShowDialogViewModel) dialogType = Assembly.Load("MVVM_Platform").GetType(dialogname);
            if (dialogType == null) throw new TypeLoadException(AppendInfoAboutDialogTypeLocators($"Dialog with name'{dialogname}' is missing"));
            cache.Add(viewModelType, dialogType);
            return dialogType;
        }

        private static string GetDialogName(Type viewModelType)
        {
            if (viewModelType .FullName !=null)
            {
                string dialogName = viewModelType.FullName.Replace(".ViewModels.", ".Views.");
                if (dialogName.EndsWith("ViewModel",StringComparison.Ordinal))
                {
                    return dialogName.Substring(0, dialogName.Length - "Model".Length);
                }
            }
            throw new TypeLoadException(AppendInfoAboutDialogTypeLocators($"View model of type '{viewModelType}'donsn't follow naming convention since it isn't suffixed with 'ViewModel'"));
        }

        private static Assembly GetAssemblyFromType(Type type) => type.Assembly;

        private static string AppendInfoAboutDialogTypeLocators(string errorMessage) => errorMessage + Environment.NewLine;
    }
}
