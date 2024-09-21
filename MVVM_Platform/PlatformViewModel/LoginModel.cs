using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IBLL;
using PlatformModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using CommunicationComponent;
using BLL;
using NLog;

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
        public bool isLogin = true;

        [ObservableProperty]
        public Dispatcher mainDisPacher;

        Logger _Logger;
        public LoginModel(ILoginBLL loginBLL, Dispatcher dispatcher)
        {
            _loginBLL=loginBLL;
            mainDisPacher = dispatcher;//实例线程调度
            AbsUnit socket =new SocketUnit("127.0.0.1,502");
            //socket.Connect();
            socket = new SerialUnit("10,19200,8,0,1");
            socket.Connect();

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
            isLogin=false;
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
                finally
                {
                    isLogin = true;
                }

            });


        }
    }
}
