using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.ViewModels
{
    public class SettingsPageViewModel : PageBase
    {
        IRegionManager _regionManager;
        public SettingsPageViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            this.TitleName = "SettingsPage";
        }
    }
}
