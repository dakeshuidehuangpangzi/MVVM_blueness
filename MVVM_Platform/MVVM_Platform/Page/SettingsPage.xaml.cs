using PlatformViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM_Platform
{
    /// <summary>
    /// SettingsPage.xaml 的交互逻辑
    /// </summary>
    public partial class SettingsPage : UserControl, INotifyPropertyChanging, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        /// <summary>
        /// 属性改变前通知
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 属性改变后通知
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanging([CallerMemberName] string propertyName = "")
        {
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }
        #endregion

        public SettingsPage()
        {
            InitializeComponent();
            this.DataContext = App.Current.Services.GetService<SettingViewModel>();
        }



        public object DataSoure
        {
            get { return (object)GetValue(DataSoureProperty); }
            set { SetValue(DataSoureProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataSoure.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataSoureProperty =
            DependencyProperty.Register("DataSoure", typeof(object), typeof(SettingsPage), new PropertyMetadata(null,OnDataSoureChange));

        private static void OnDataSoureChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (SettingsPage)d;
            if (e.NewValue!=null)
            {
                control.OnPropertyChanging(nameof(DataSoure));
                control.SetValue(DataSoureProperty, e.NewValue);
                control.OnPropertyChanging(nameof(DataSoure));
                if (control.DataSoure!=null)
                {

                }

            }
        }
    }
}
