using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Reloj_Project
{
    class Menutexto : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int) value < 1) {
                return (String) "Reloz Analogico - Modo 1";
            }
            if ((int)value > 1 && (int)value < 2) {
                return (String) "Reloz Analogico - Modo 2";
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
