using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using MQTTnet.Protocol;
namespace Assets
{
    public class InValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //value  ：传递的值

            //parameter ：范围
            if (value is bool)
            {
                var str = (bool)value ? "true" : "false";
                if (value != null && parameter != null && str == parameter.ToString())
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;

           
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter;
        }
    }

    public class InIntValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && parameter != null && value.ToString() == parameter.ToString())
            {
                return true;
            }
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter;
        }
    }


    public class OSValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                switch ((MqttQualityOfServiceLevel)value)
                {
                    case MqttQualityOfServiceLevel.AtMostOnce: return "0";
                    case MqttQualityOfServiceLevel.AtLeastOnce:return "1";
                    case MqttQualityOfServiceLevel.ExactlyOnce:return "2";
                    default: return "0";
                }
            }
            else
                return "0";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter;
        }
    }

}
