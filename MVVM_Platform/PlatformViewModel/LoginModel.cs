using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlatformModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PlatformViewModel
{
    public partial class LoginModel:ObservableObject
    {
        [ObservableProperty]
        UserModel user=new UserModel();

        [RelayCommand]
        public void Login( object obj)
        {
            (obj as Window).DialogResult = false;
        }
    }
}
