using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using Kurs.Model;

namespace Kurs.Converters
{
    internal class ToBuyerFIO : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int id = int.Parse(value.ToString());
            using (ModelContext db = new ModelContext())
            {
                return db.Buyer.Where(p => p.ID_Buyer == id).Select(p => p.FirstName + " " + p.SecondName + "." + p.LastName).FirstOrDefault();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
