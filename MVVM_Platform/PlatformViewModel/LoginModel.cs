using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IBLL;
using PlatformModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace PlatformViewModel
{
    public partial class LoginModel:ObservableObject
    {
        [ObservableProperty]
        UserModel user=new UserModel();
        ILoginBLL _loginBLL;
        [ObservableProperty]
        string errorMessage;

        [ObservableProperty]
        public Dispatcher mainDisPacher;


        public LoginModel(ILoginBLL loginBLL, Dispatcher dispatcher)
        {
            _loginBLL=loginBLL;
            mainDisPacher = dispatcher;//实例线程调度
        }

        [RelayCommand]
        public void Login( object obj)
        {
            ErrorMessage = "";
            if (string.IsNullOrEmpty(User.UserName))
            {
                ErrorMessage = "用户名不能为空";
                return;
            }
            if (string.IsNullOrEmpty(User.Password))
            {
                ErrorMessage = "密码不能为空"; 
                return;
            }
            Task.Run(async() => {
                try
                {
                    var user = await _loginBLL.Login(User.UserName, User.Password);
                    mainDisPacher.Invoke(() => 
                    {
                        (obj as Window).DialogResult = true;
                    });
                    
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                }

            });


        }
    }
}
