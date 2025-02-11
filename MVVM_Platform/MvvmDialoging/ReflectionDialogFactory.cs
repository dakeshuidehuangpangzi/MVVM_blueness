using Platform.Extensions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmDialoging
{
    public class ReflectionDialogFactory : IDialogFactory
    {
        public iWindow Create(Type dialogType)
        {
            if (dialogType == null) throw new ArgumentNullException(nameof(dialogType));
            var instance = Activator.CreateInstance(dialogType);
            return instance switch
            {
                iWindow customDialog => customDialog,
                Window dialog=>new WindowWrapper(dialog),
                _=>throw new ArgumentException($"Only dialogs of type{typeof(Window)}or {typeof(iWindow)}are supported")
            };
        }
    }
}
