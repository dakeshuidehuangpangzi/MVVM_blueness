using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.ViewModels
{
    public class AlarmPageViewModel:PageBase
    {
        IRegionManager _regionManager;
        public AlarmPageViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            this.TitleName = "AlarmPage";
        }
    }
}
