using Kurs.Model;
using Kurs.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Kurs.ViewModel
{
    internal class SaleManViewModel
    {
        ModelContext db = new ModelContext();
        RelayCommand? addCommand;
        RelayCommand? editCommand;
        RelayCommand? deleteCommand;
        public ObservableCollection<SalesMan> SalesMans { get; set; }

        public SaleManViewModel()
        {
            db.Database.EnsureCreated();
            db.SalesMan.Load();
            SalesMans = db.SalesMan.Local.ToObservableCollection();
        }
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      AddEditSaleMan dialog = new AddEditSaleMan(new SalesMan());
                      if (dialog.ShowDialog() == true)
                      {
                          SalesMan user = dialog.SaleMan;
                          db.SalesMan.Add(user);
                          db.SaveChanges();
                      }
                  }));
            }
        }
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((selectedItem) =>
                  {
                      // получаем выделенный объект
                      SalesMan? realtor = selectedItem as SalesMan;
                      if (realtor == null) return;

                      Realtor vm = new Realtor
                      {
                          id_realtor = realtor.id_SalesMan,
                          FirstName = realtor.FirstName,
                          SecondName = realtor.SecondName,
                          LastName = realtor.LastName,
                          Passport = realtor.Passport
                      };
                      AddEditRealtorView userWindow = new AddEditRealtorView(vm);


                      if (userWindow.ShowDialog() == true)
                      {
                          realtor.FirstName = userWindow.Realtor.FirstName;
                          realtor.SecondName = userWindow.Realtor.SecondName;
                          realtor.LastName = userWindow.Realtor.LastName;
                          realtor.Passport = userWindow.Realtor.Passport;
                          db.Entry(realtor).State = EntityState.Modified;
                          db.SaveChanges();
                      }
                  }));
            }
        }
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand((selectedItem) =>
                  {
                      // получаем выделенный объект
                      SalesMan? user = selectedItem as SalesMan;
                      if (user == null) return;
                      db.SalesMan.Remove(user);
                      db.SaveChanges();
                  }));
            }
        }
    }
}
