using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlatformModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PlatformViewModel
{
    public partial class MainViewModel: ObservableObject
    {
        public List<MenuModel> Menus { get; set; }

        [ObservableProperty]
        public object viewContent;

        public MainViewModel()
        {
            #region 主窗口菜单 
            Menus = new List<MenuModel>();
            Menus.Add(new MenuModel
            {
                IsSelected = true,
                MenuHeader = "监控",
                MenuIcon = "\ue639",
                TargetView = "MonitorPage"
            });
            Menus.Add(new MenuModel
            {
                MenuHeader = "趋势",
                MenuIcon = "\ue61a",
                TargetView = "TrendPage"
            });
            Menus.Add(new MenuModel
            {
                MenuHeader = "报警",
                MenuIcon = "\ue60b",
                TargetView = "AlarmPage"
            });
            Menus.Add(new MenuModel
            {
                MenuHeader = "报表",
                MenuIcon = "\ue703",
                TargetView = "ReportPage"
            });
            Menus.Add(new MenuModel
            {
                MenuHeader = "配置",
                MenuIcon = "\ue60f",
                TargetView = "SettingsPage"
            });
            Menus.Add(new MenuModel
            {
                MenuHeader = "报警曲线",
                MenuIcon = "\ue60f",
                TargetView = "TrendPage"
            }); 
            Menus.Add(new MenuModel
            {
                MenuHeader = "历史记录",
                MenuIcon = "\ue60f",
                TargetView = "HistoryPage"
            }); 
            Menus.Add(new MenuModel
            {
                MenuHeader = "手动控制",
                MenuIcon = "\ue60f",
                TargetView = "ManualOperationPage"
            });
            #endregion


            ShowPage(Menus[0]);
        }

        [RelayCommand]
        private void ShowPage(object obj)
        {
            // Bug：对象会重复创建，需要处理
            // 第80行解决

            var model = obj as MenuModel;
            this.Menus.FirstOrDefault(x=>x.MenuHeader==model.MenuHeader).IsSelected=true;
            //this.Menus[0].IsSelected = true;
            //if (model != null)
            //{

            //if (GlobalUserInfo.UserType == 0 && model.TargetView != "MonitorPage")
            //{
            //    // 提示权限
            //    this.Menus[0].IsSelected = true;
            // 提示没有权限操作
            //if (ActionManager.ExecuteAndResult<object>("ShowRight", null))
            //{
            //    // 执行重新登录
            //    DoLogout();
            //}
            //}
            //else
            //{
            if (ViewContent != null && ViewContent.GetType().Name == model.TargetView) return;

            Type type = Assembly.Load("MVVM_Platform")
                .GetType("MVVM_Platform." + model.TargetView)!;
            ViewContent = Activator.CreateInstance(type)!;
            //}
            //}
        }

    }
}
