using HalconDotNet;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Platform.Views
{
    /// <summary>
    /// MonitorPage.xaml 的交互逻辑
    /// </summary>
    public partial class MonitorPage : UserControl
    {
        public MonitorPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var imageDialog = new Microsoft.Win32.OpenFileDialog();
            imageDialog.Filter = "图片|*.jpg;*.jpeg;*.png;*.bmp;*.tif;*.tiff";
            imageDialog.DefaultExt = ".jpg";
            if (imageDialog.ShowDialog() == true)
            {
                var hObject = imageDialog.FileName;
                var image = new HImage();
                image.ReadImage(hObject);
                HsHalcon.HalconWindow.DispObj(image);
            }
        }
        private HObject Ho_Image = null;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            HObject ho_Image;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Image);
            ho_Image.Dispose();
            HOperatorSet.ReadImage(out ho_Image, "C:/Users/Public/Documents/MVTec/HALCON-12.0/examples/images/rim.png");
            //ho_Image.Dispose();


            //HOperatorSet.GenEmptyObj(out Ho_Image);
            //Ho_Image.Dispose();
            //HTuple hv_WindowHandle;
            ////halcon算子,读取图片
            //HOperatorSet.ReadImage(out Ho_Image, @"‪F:\00.PNG");
            // 显示属性
            HsHalcon.HalconWindow.SetColor("red");
            HsHalcon.HalconWindow.SetLineWidth(1);
            HsHalcon.HalconWindow.DispObj(ho_Image);
            //HalconWPF.SetFullImagePart(ho_Image);
            //// 锁定
            //DrawingCanvas.Strokes.Clear();
            //BoolEditMode = false;
            //IsMakingModule = true;
            //StrInfo = "null";
        }
        private void ButtonEvent(string name)
        {
            // 创建模板
            if (name == "Create")
            {
               
            }
        }

    }

}
