using Kurs.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Kurs.Converters
{
    internal class FromRealEstate : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int id=int.Parse(value.ToString());
            using (ModelContext db=new ModelContext())
            {
                return db.RealEstate.Where(p=>p.ID_Estate==id).Select(p=>p.House+","+p.Street+","+p.Department).FirstOrDefault();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
