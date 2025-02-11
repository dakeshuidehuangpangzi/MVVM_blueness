using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public partial class MenuModel : ObservableObject
    {
        private bool _isSelected;
        [ObservableProperty]

        public bool isSelected = false;
        public int Key { get; set; }
        public string MenuHeader { get; set; }
        public string TargetView { get; set; }
        public string MenuIcon { get; set; }

    }
}
