using Platform.Global;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Platform.Models
{
    public class MenuItemModel:BindableBase
    {
        /// <summary> 选项名词</summary>
        public string Name { get; set; }
        /// <summary> 图片</summary>
        public string Icone { get; set; }
        /// <summary> 导航的窗体名词</summary>
        public string TargetViewName { get; set; }

        private bool _isExpanded;
        // 是否展开节点
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set { SetProperty(ref _isExpanded, value); }
        }
        /// <summary> 子节点</summary>
        public ObservableCollection<MenuItemModel> Items { get; set;}=new ObservableCollection<MenuItemModel>();

        private ICommand openViewCommand;

        public ICommand OpenViewCommand
        {
            get {
                if (openViewCommand==null)
                {
                    openViewCommand = new DelegateCommand<MenuItemModel>(DoOpenViewCommand);
                }
                return openViewCommand;
            }
        }

        IRegionManager _regionManager;
        public MenuItemModel(IRegionManager regionManager)
        {
            _regionManager=regionManager;
        }

        private void DoOpenViewCommand(MenuItemModel model)
        {
            //是打开节点还是打开窗体
            //打开窗体条件，子节点是无，并且目标窗体名字是有的
            if ((model.Items.Count == 0 || model.Items == null)&&!string.IsNullOrEmpty(model.TargetViewName))
                _regionManager.RequestNavigate(GlobalRegionName.MainViewRegionName, model.TargetViewName);
            else
                IsExpanded = !IsExpanded;

        }

    }
}
