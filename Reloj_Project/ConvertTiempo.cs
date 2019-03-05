using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Reloj_Project
{

    class ConvertTiempo : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((String)parameter) {

                case "seg_min":
                    return value = (double)value * 360 / 60;
                case "horas":
                    return value = ((double)value % 12) * 360 / 12;
                default:
                    return -1;


            }
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
