using Kurs.Model;
using Kurs.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Kurs.ViewModel
{
   public class RealtorViewModel
    {
        ModelContext db = new ModelContext();
        RelayCommand? addCommand;
        RelayCommand? editCommand;
        RelayCommand? deleteCommand;
        public ObservableCollection<Realtor> Realtors { get; set; }

        public RealtorViewModel()
        {
            db.Database.EnsureCreated();
            db.Realtor.Load();
            Realtors = db.Realtor.Local.ToObservableCollection();
        }
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      AddEditRealtorView dialog = new AddEditRealtorView(new Realtor());
                      if (dialog.ShowDialog() == true)
                      {
                          Realtor user = dialog.Realtor;
                          db.Realtor.Add(user);
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
                      Realtor? realtor = selectedItem as Realtor;
                      if (realtor == null) return;

                      Realtor vm = new Realtor
                      {
                          id_realtor= realtor.id_realtor,
                          FirstName = realtor.FirstName,
                          SecondName = realtor.SecondName,
                          LastName = realtor.LastName,
                          Passport=realtor.Passport
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
                      Realtor? user = selectedItem as Realtor;
                      if (user == null) return;
                      db.Realtor.Remove(user);
                      db.SaveChanges();
                  }));
            }
        }
    }
}
