using Platform.Extensions.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Platform.Extensions.Interfaces
{
    public interface iWindow
    {
        object DataContext { get; set; }
        bool? DialogResult { get; set; }
        ContentControl? Owner { get; set; }

        bool? ShowDialg();
        void Show();
        void Close();
        void Click3Btn(EDialogResult result);
        void SetWindowStartupLocation(WindowStartupLocation windowStartupLocation = WindowStartupLocation.CenterScreen);
    }
}
