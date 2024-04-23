using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.ViewModels
{
    public class ReportPageViewModel : PageBase
    {
        IRegionManager _regionManager;
        public ReportPageViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            this.TitleName = "ReportPage";
        }
    }
}
