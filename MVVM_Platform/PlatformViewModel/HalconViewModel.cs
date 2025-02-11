global using CommunityToolkit.Mvvm.ComponentModel;
global using CommunityToolkit.Mvvm.Input;
using HalconDotNet;
using System.Windows;


namespace PlatformViewModel
{
    public partial class HalconViewModel : ObservableObject
    {
        private HSmartWindowControlWPF HsHalcon { get; set; }


        /// <summary>
        /// 获取视觉控件   一点要添加System.Drawing.Common 这个类库 但不能使用8以上的  不然会出异常
        /// </summary>
        /// <param name="obj"></param>
        [RelayCommand]
        public void Loadinfo(object obj)
        {
            HsHalcon = (obj as HSmartWindowControlWPF);
        }
        [RelayCommand]
        public void OpenImage()
        {
            var imageDialog = new Microsoft.Win32.OpenFileDialog();
            imageDialog.Filter = "图片|*.jpg;*.jpeg;*.png;*.bmp;*.tif;*.tiff";
            imageDialog.DefaultExt = ".jpg";
            if (imageDialog.ShowDialog() == true)
            {
                var hObject = imageDialog.FileName;
                var image = new HImage();
                image.ReadImage(hObject);
                //避免显示上一张图片
                HsHalcon.HalconWindow.ClearWindow();
                HsHalcon.HalconWindow.DispObj(image);
                //Halcon.HalconWindow.DispObj(image);

            }
        }

    }
}
