using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AnalogClockControl.Converters
{
    internal class GreaterThanMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values != null && values.Length == 2 &&//Checking that we have a width and a height
                double.TryParse(values[0].ToString(), out double nb0) && //Convert the values to double instead
                double.TryParse(values[1].ToString(), out double nb1) ? 
                nb0>nb1 : // if true we check the size
                false; 
        }
        
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
