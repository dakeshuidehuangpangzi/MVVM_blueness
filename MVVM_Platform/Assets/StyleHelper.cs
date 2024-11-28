
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Assets
{
    public class TextBoxHelper
    {
        #region Watermark
        public static string GetWatermark(DependencyObject obj)
        {
            return (string)obj.GetValue(WatermarkProperty);
        }

        public static void SetWatermark(DependencyObject obj, string value)
        {
            obj.SetValue(WatermarkProperty, value);
        }

        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.RegisterAttached("Watermark", typeof(string), typeof(TextBoxHelper), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        #endregion

        #region Description
        public static string GetDescription(DependencyObject obj)
        {
            return (string)obj.GetValue(DescriptionProperty);
        }

        public static void SetDescription(DependencyObject obj, string value)
        {
            obj.SetValue(DescriptionProperty, value);
        }

        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.RegisterAttached("Description", typeof(string), typeof(TextBoxHelper), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region SubText
        public static object GetSubText(DependencyObject obj)
        {
            return (object)obj.GetValue(SubTextProperty);
        }

        public static void SetSubText(DependencyObject obj, object value)
        {
            obj.SetValue(SubTextProperty, value);
        }

        public static readonly DependencyProperty SubTextProperty =
            DependencyProperty.RegisterAttached("SubText", typeof(object), typeof(TextBoxHelper), new FrameworkPropertyMetadata(default, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region SuffixText
        public static string GetSuffix(DependencyObject obj)
        {
            return (string)obj.GetValue(SuffixProperty);
        }

        public static void SetSuffix(DependencyObject obj, string value)
        {
            obj.SetValue(SuffixProperty, value);
        }

        public static readonly DependencyProperty SuffixProperty =
            DependencyProperty.RegisterAttached("Suffix", typeof(string), typeof(TextBoxHelper), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion

        #region TextWidth
        public static double GetTextWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(TextWidthProperty);
        }

        public static void SetTextWidth(DependencyObject obj, double value)
        {
            obj.SetValue(TextWidthProperty, value);
        }

        public static readonly DependencyProperty TextWidthProperty =
            DependencyProperty.RegisterAttached("TextWidth", typeof(double), typeof(TextBoxHelper));

        #endregion

        #region DescriptionWidth
        public static double GetDescriptionWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(DescriptionWidthProperty);
        }

        public static void SetDescriptionWidth(DependencyObject obj, double value)
        {
            obj.SetValue(DescriptionWidthProperty, value);
        }

        public static readonly DependencyProperty DescriptionWidthProperty =
            DependencyProperty.RegisterAttached("DescriptionWidth", typeof(double), typeof(TextBoxHelper));

        #endregion

        #region SuffixWidth
        public static double GetSuffixWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(SuffixWidthProperty);
        }

        public static void SetSuffixWidth(DependencyObject obj, double value)
        {
            obj.SetValue(SuffixWidthProperty, value);
        }

        public static readonly DependencyProperty SuffixWidthProperty =
            DependencyProperty.RegisterAttached("SuffixWidth", typeof(double), typeof(TextBoxHelper));

        #endregion
    }

    #region String IsNullOrEmpty
    public class IsNullOrEmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.IsNullOrEmpty((string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
    #endregion
}
