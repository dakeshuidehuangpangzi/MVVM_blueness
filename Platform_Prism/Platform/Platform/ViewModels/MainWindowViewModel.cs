﻿using Entity;
using Platform.Models;
using PlcPlatform;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Platform.ViewModels
{
    public  class MainWindowViewModel:BindableBase
    {

        public ObservableCollection<MenuItemModel> MenuItems { get; set; } = new ObservableCollection<MenuItemModel>();

        IRegionManager _regionManager = null;
        public ICommand CloseCommand { get; set; }


        public MainWindowViewModel(IRegionManager regionManager)
        {

            _regionManager = regionManager;
            CloseCommand=new DelegateCommand(()=>Application.Current.Shutdown());
            //先虚构几个选择
            MenuItems.Add(new MenuItemModel(_regionManager)
            {
                Name= "监控",
                Icone="\ue1355",
                TargetViewName= "MonitorPage"
            });
            MenuItems.Add(new MenuItemModel(_regionManager)
            {
                Name = "报警",
                Icone = "\ue1355",
                TargetViewName = "AlarmPage"
            });
            MenuItems.Add(new MenuItemModel(_regionManager)
            {
                Name = "报表",
                Icone = "\ue1355",
                TargetViewName = "ReportPage"
            });
            MenuItems.Add(new MenuItemModel(_regionManager)
            {
                Name = "配置",
                Icone = "\ue1355",
                TargetViewName = "SettingsPage"
            });
            MenuItems.Add(new MenuItemModel(_regionManager)
            {
                Name = "报警曲线",
                Icone = "\ue1355",
                TargetViewName = "TrendPage"
            });
            MenuItems.Add(new MenuItemModel(_regionManager)
            {
                Name = "历史记录",
                Icone = "\ue1355",
                TargetViewName = "HistoryPage"
            });
            //SocketUnit socket=new SocketUnit();
            //var resutl= socket.Connect();
            //if (!resutl.Started)
            //    throw new Exception();

        }
    }
}
