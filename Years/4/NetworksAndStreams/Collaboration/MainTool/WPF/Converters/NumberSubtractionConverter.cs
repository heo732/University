using System;
using System.Globalization;
using System.Windows.Data;

namespace MainTool.WPF.Converters
{
    public class NumberSubtractionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double v = 0;
            double p = 0;

            if (value is double v_double)
            {
                v = v_double;
            }
            else if (value is int v_int)
            {
                v = v_int;
            }
            else if ((value is string v_string) && double.TryParse(v_string, out v))
            { }

            if (parameter is double p_double)
            {
                p = p_double;
            }
            else if (parameter is int p_int)
            {
                p = p_int;
            }
            else if ((parameter is string p_string) && double.TryParse(p_string, out p))
            { }

            return v - p;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}