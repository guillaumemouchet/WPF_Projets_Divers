using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DataBindingExercices.CustomConverters
{
    public class EnumDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TestEnums testEnum = (TestEnums)value;
            string descritpion = GetEnumDescription(testEnum);
            return descritpion;
        }

        private string GetEnumDescription(TestEnums testEnum)
        {
            FieldInfo fi = testEnum.GetType().GetField(testEnum.ToString());

            object[] attribArray = fi.GetCustomAttributes(false);

            if (attribArray.Length == 0)
            {
                return testEnum.ToString();
            }
            else
            {
                DescriptionAttribute attrib = attribArray[0] as DescriptionAttribute;
                return attrib.Description;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Empty;
        }
    }
}
