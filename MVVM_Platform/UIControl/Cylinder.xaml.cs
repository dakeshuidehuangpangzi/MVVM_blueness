using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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

namespace UIControl
{
    /// <summary>
    /// Cylinder.xaml 的交互逻辑
    /// </summary>
    public partial class Cylinder : UserControl
    {
        public Cylinder()
        {
            InitializeComponent();
        }


        #region 依赖属性

        public static string GetHeader(DependencyObject obj)
        {
            return (string)obj.GetValue(HeaderProperty);
        }

        public static void SetHeader(DependencyObject obj, string value)
        {
            obj.SetValue(HeaderProperty, value);
        }
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(Cylinder), new PropertyMetadata("999",new PropertyChangedCallback(HeadChanger)));

        private static void HeadChanger(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SetHeader(d, e.NewValue.ToString());
        }

        public static bool GetIsFilcher(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsFilcherProperty);
        }

        public static void SetIsFilcher(DependencyObject obj, bool value)
        {
            obj.SetValue(IsFilcherProperty, value);
        }

        //判断是否需要闪烁
        public static readonly DependencyProperty IsFilcherProperty =
            DependencyProperty.RegisterAttached("IsFilcher", typeof(bool), typeof(Cylinder), new PropertyMetadata(false));



        public static bool GetExtend(DependencyObject obj)
        {
            return (bool)obj.GetValue(ExtendProperty);
        }

        public static void SetExtend(DependencyObject obj, bool value)
        {
            obj.SetValue(ExtendProperty, value);
        }

        // Using a DependencyProperty as the backing store for Extend.  This enables animation, styling, binding, etc...
        /// <summary>伸出(Clidenly为true，有信号输出)</summary>
        public static readonly DependencyProperty ExtendProperty =
            DependencyProperty.RegisterAttached("Extend", typeof(bool), typeof(Cylinder), new PropertyMetadata(false));


        public static bool GetRetract(DependencyObject obj)
        {
            return (bool)obj.GetValue(RetractProperty);
        }

        public static void SetRetract(DependencyObject obj, bool value)
        {
            obj.SetValue(RetractProperty, value);
        }

        // Using a DependencyProperty as the backing store for Retract.  This enables animation, styling, binding, etc...
        /// <summary>缩回(Clidenly为false，有信号输出)</summary>
        public static readonly DependencyProperty RetractProperty =
            DependencyProperty.RegisterAttached("Retract", typeof(bool), typeof(Cylinder), new PropertyMetadata(false));

        public static bool GetOutPut(DependencyObject obj)
        {
            return (bool)obj.GetValue(OutPutProperty);
        }

        public static void SetOutPut(DependencyObject obj, bool value)
        {
            obj.SetValue(OutPutProperty, value);
        }

        // Using a DependencyProperty as the backing store for OutPut.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OutPutProperty =
            DependencyProperty.RegisterAttached("OutPut", typeof(bool), typeof(Cylinder), new PropertyMetadata(false));




        #endregion




    }
}
