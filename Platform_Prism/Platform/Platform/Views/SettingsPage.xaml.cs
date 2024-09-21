using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Platform.Views
{
    /// <summary>
    /// SettingsPage.xaml 的交互逻辑
    /// </summary>
    public partial class SettingsPage : UserControl
    {
        public SettingsPage()
        {
            InitializeComponent();
        }
        private void CHECK()
        {
            int index = dg.CurrentCell.Column.DisplayIndex;
            DataGridTemplateColumn templateColumn = dg.Columns[index] as DataGridTemplateColumn;
            if (templateColumn == null) return;
            object cellContent = dg.CurrentCell.Item; ;
            FrameworkElement element = templateColumn.GetCellContent(cellContent);
            Popup popup= templateColumn.GetCellContent(cellContent) as Popup;
            if (popup!= null)   
                popup.CustomPopupPlacementCallback = new CustomPopupPlacementCallback(placePopup);
        }


        private CustomPopupPlacement[] placePopup(Size popupSize, Size targetSize, Point offset)
        {

            //CustomPopupPlacement placement = new CustomPopupPlacement(new Point(targetSize.Width - popupSize.Width, targetSize.Height - popupSize.Height), PopupPrimaryAxis.Vertical);
            CustomPopupPlacement placement1 = new CustomPopupPlacement(new Point(-2, 35), PopupPrimaryAxis.Vertical);
            CustomPopupPlacement placement2 = new CustomPopupPlacement(new Point(10, 20), PopupPrimaryAxis.Horizontal);
            CustomPopupPlacement[] ttplaces = new CustomPopupPlacement[] { placement1, placement2 };
            return ttplaces;
        }
    }
}
