using Platform.Extensions.Enum;
using Platform.Extensions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MvvmDialoging
{
    public class WindowWrapper : iWindow
    {
        private readonly Window window;
        public WindowWrapper(Window window) => this.window = window ?? throw new ArgumentNullException(nameof(window));
        
        public object DataContext { get => window.DataContext; set => window.DataContext = value; }
        public bool? DialogResult { get => window.DialogResult; set => window.DialogResult=value; }
        public ContentControl? Owner { get => window.Owner; set => window.Owner=(Window?)value; }

        public void Click3Btn(EDialogResult result)
        {
            window.Dispatcher.Invoke(() => {
                if (window.DataContext!=null && window.DataContext is ViewModelBaseDialogAsync viewModel)
                {
                    viewModel.DialogResult = result;
                }
                window.Close();
            });
        }

        public void Close() => window.Close();

        public void SetWindowStartupLocation(WindowStartupLocation windowStartupLocation = WindowStartupLocation.CenterScreen) => window.WindowStartupLocation = windowStartupLocation;

        public void Show() => window.Show();

        public bool? ShowDialg() => window.ShowDialog();
    }
}
