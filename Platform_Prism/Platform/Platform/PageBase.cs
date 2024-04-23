using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Platform
{
    public class PageBase:BindableBase, INavigationAware
    {
        public string TitleName { get; set; } = "Page";

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;
        // 是否允许关闭
        public bool IsCanClose { get; set; } = true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }
    }
}
