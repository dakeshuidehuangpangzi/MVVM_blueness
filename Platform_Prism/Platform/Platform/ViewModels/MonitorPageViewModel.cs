using Microsoft.VisualBasic;
using Platform.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using HalconDotNet;
using System.Diagnostics;
using Platform.Models;

namespace Platform.ViewModels
{
    public class MonitorPageViewModel: PageBase
    {
        IRegionManager _regionManager;
        public MonitorPageViewModel(IRegionManager regionManager)
        {
             _regionManager = regionManager;
            this.TitleName = "Monitor";
            CmdLoaded = new DelegateCommand<RoutedEventArgs>(Loaded);
            CmdSizeChanged =new DelegateCommand(SizeChanged);
            CmdOpenImage =new DelegateCommand(OpenImage);
            DrawCommand=new DelegateCommand<string>(Drawing);
            CmdButtonEvent =new DelegateCommand<string>(ButtonEvent);
           // CmdLoaded => new Lazy<RelayCommand<RoutedEventArgs>>(() => new RelayCommand<RoutedEventArgs>(Loaded)).Value;
        }

        private HWindowControlWPF Halcon { get; set; }
        private HSmartWindowControlWPF HsHalcon { get; set; }

        //private HWindow Ho_Window { get; set; } = new HWindow();
        private InkCanvas DrawingCanvas { get; set; }
        private Border DrawingBorder { get; set; }



        /// <summary>
        /// 缩放参数
        /// </summary>
        private int WheelScrollValue { get; set; } = 0;
        private int WheelScrollMin { get; set; } = -5;
        private int WheelScrollMax { get; set; } = -15;

        /// <summary>
        /// 绘制模板 编辑
        /// </summary>
        private Point PointMoveOri { get; set; } = new Point();
        private bool IsMakingModule { get; set; } = false;
        private bool IsEditingModule { get; set; } = false;
        private bool CanMove { get; set; } = false;
        //private EnumModuleEditType ModuleEditType { get; set; }
        private HTuple Hv_ShapeModelID = new HTuple();


        private HObject Ho_Image = null;

        public ICommand CmdLoaded { get; set; }
        public ICommand CmdSizeChanged { get; set; }
        public ICommand CmdOpenImage { get; set; }
        public ICommand CmdButtonEvent { get; set; }

        public ICommand DrawCommand { get; set; }

        private void Loaded(RoutedEventArgs e)
        {
            Halcon = (e.Source as MonitorPage).HalconWPF;
            HsHalcon = (e.Source as MonitorPage).HsHalcon;

            // Ho_Window = (e.Source as MonitorPage).HalconWPF.HalconWindow;
            //DrawingCanvas = (e.Source as MeasureTools).DrawingCanvas;
            //DrawingBorder = (e.Source as MeasureTools).DrawingBorder;

            // 鼠标事件
            //DrawingBorder.MouseWheel += DrawingBorder_MouseWheel;
            //DrawingBorder.MouseLeftButtonDown += DrawingBorder_MouseLeftButtonDown;
            //DrawingBorder.MouseMove += DrawingBorder_MouseMove;
            //DrawingBorder.MouseLeftButtonUp += DrawingBorder_MouseLeftButtonUp;
            //DrawingBorder.MouseRightButtonDown += DrawingBorder_MouseRightButtonDown;
        }

        /// <summary>
        /// 窗体尺寸变化后 图像会自动自适应
        /// </summary>
        private void SizeChanged()
        {
            WheelScrollValue = 0;
            // 清空 Strokes
            DrawingCanvas.Strokes.Clear();
        }
        private void ButtonEvent(string name)
        {
            // 创建模板
            if (name == "Create")
            {
                HOperatorSet.GenEmptyObj(out Ho_Image);
                Ho_Image.Dispose();
                HOperatorSet.ReadImage(out Ho_Image, fileName: @"C:\\Users\\Public\\Documents\\MVTec\\HALCON-20.11-Steady\\examples\\images\\hydraulic_engineering\\hydraulic_engineering_04.png");
                // 显示属性
                //Halcon.HalconWindow.SetColor("red");
                //Halcon.HalconWindow.SetLineWidth(1);
                //Halcon.HalconWindow.DispObj(Ho_Image);
                //Halcon.SetFullImagePart(null);


                HsHalcon.HalconWindow.SetColor("red");
                HsHalcon.HalconWindow.SetLineWidth(1);
                HsHalcon.HalconWindow.DispObj(Ho_Image);
                HsHalcon.SetFullImagePart();
                // 锁定
                //DrawingCanvas.Strokes.Clear();
                //BoolEditMode = false;
                //IsMakingModule = true;
                //StrInfo = "null";
            }
        }

        /// <summary>
        /// 编辑模式
        /// </summary>
        private bool boolEditMode;
        public bool BoolEditMode
        {
            get => boolEditMode;
            set => SetProperty(ref boolEditMode, value);
        }

        // 显示信息
        private string strInfo;
        public string StrInfo
        {
            get => strInfo;
            set => SetProperty(ref strInfo, value);
        }
        private void OpenImage()
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


        List<HDrawingObject> hDrawingObjects = new List<HDrawingObject>();
        List<DrawingObjectExtension> drawingObjectExtensions=new List<DrawingObjectExtension>();
        private void Drawing(string draw)
        {
            var hdrc=HDrawingObject.CreateDrawingObject(HDrawingObject.HDrawingObjectType.RECTANGLE1, new HTuple[]{100,100,300,300});
            hDrawingObjects.Clear();

            switch (draw)
            {
                case "RECTANGLE2":
                    hdrc = HDrawingObject.CreateDrawingObject(HDrawingObject.HDrawingObjectType.RECTANGLE2, new HTuple[] { 100, 100, 300, 300 });
                    break;
                case "ELLIPSE":
                    hdrc = HDrawingObject.CreateDrawingObject(HDrawingObject.HDrawingObjectType.ELLIPSE, new HTuple[] { 100, 100,150, 150, 100, 100 });
                    break;
                case "CIRCLE":
                    hdrc = HDrawingObject.CreateDrawingObject(HDrawingObject.HDrawingObjectType.CIRCLE, new HTuple[] { 100, 100, 100 });
                    hdrc.OnDrag(HDrawingObjectCallbackClass);
                    hdrc.OnResize(HDrawingObjectCallbackClass);
                    drawingObjectExtensions.Add(new DrawingObjectExtension()
                    {
                        DrawObj = hdrc,
                        HTuples=new HTuple[] { 100, 100, 100 },
                    });
                    break;
                case "Polygon":
                    hdrc = HDrawingObject.CreateDrawingObject(HDrawingObject.HDrawingObjectType.RECTANGLE1, new HTuple[] { 100, 100, 300, 300 });
                    break;
                case "Text":
                    hdrc = HDrawingObject.CreateDrawingObject(HDrawingObject.HDrawingObjectType.RECTANGLE1, new HTuple[] { 100, 100, 300, 300 });
                    break;
                case "Clear":
                    hdrc = HDrawingObject.CreateDrawingObject(HDrawingObject.HDrawingObjectType.RECTANGLE1, new HTuple[] { 100, 100, 300, 300 });
                    break;
                default:
                    break;
            }
            hDrawingObjects.Add(hdrc);
            HsHalcon.HalconWindow.AttachDrawingObjectToWindow(hdrc);
        }

        private void HDrawingObjectCallbackClass(HDrawingObject drawid, HWindow window, string type)
        {
           var row=drawid.GetDrawingObjectParams("row");
            var column = drawid.GetDrawingObjectParams("column");
            var radius = drawid.GetDrawingObjectParams("radius");  
            var Tuples=new HTuple[] { row, column, radius };
            var obj= drawingObjectExtensions.FirstOrDefault(x => x.DrawObj == drawid);
            if (obj!= null)
            {
                obj.HTuples = Tuples;
            }   
            Debug.WriteLine($"回调函数{row}，{column},{radius}");
        }



        private void CreateTemplate()
        {
            var roiattr = drawingObjectExtensions[0].HTuples;
            //HOperatorSet.GenCircle(out ho_template, roiattr[0], roiattr[1], roiattr[2])
            HOperatorSet.GenEmptyObj(out Ho_Image);
            Ho_Image.Dispose();
            HOperatorSet.ReadImage(out Ho_Image, @"Image\calibration_circle.bmp");
            // 显示属性
            HsHalcon.HalconWindow.SetColor("red");
            HsHalcon.HalconWindow.SetLineWidth(1);
            HsHalcon.HalconWindow.DispObj(Ho_Image);
            HsHalcon.SetFullImagePart();
        }

    }
}
