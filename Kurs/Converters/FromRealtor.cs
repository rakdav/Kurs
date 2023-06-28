using Kurs.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Kurs.Converters
{
    public class FromRealtor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int id = int.Parse(value.ToString());
            using (ModelContext db = new ModelContext())
            {
                return db.Realtor.Where(p=>p.id_realtor==id).Select(p=>p.FirstName+" "+p.SecondName+" "+p.LastName).FirstOrDefault();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
