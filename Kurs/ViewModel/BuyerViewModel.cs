using Kurs.Model;
using Kurs.View;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Kurs.ViewModel
{
    class BuyerViewModel : INotifyPropertyChanged
    {
        ModelContext db = new ModelContext();
        private BuyerWindow window;
        private Buyer selectedBuyer;
        public ObservableCollection<Buyer> BuyersList { get; set; }
        public Buyer SelectedBuyer
        {
            get { return selectedBuyer; }
            set
            {
                selectedBuyer = value;
                OnPropertyChanged("SelectedBuyer");
            }
        }
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Buyer buyer=new Buyer();
                      buyer.FirstName = window.FirstName.Text;
                      buyer.SecondName = window.SecondName.Text;
                      buyer.LastName = window.LastName.Text;
                      buyer.DateBirth = window.DateBirth.Text;
                      buyer.Passport = window.Passport.Text;
                      buyer.Address = window.Address.Text;
                      BuyersList.Add(buyer);
                      db.Buyer.Add(buyer);
                      db.SaveChanges();
                             
                  }));
            }
        }
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      Buyer byuer = obj as Buyer;
                      BuyersList.Remove(byuer);
                      if (byuer == null) return;
                      db.Buyer.Remove(byuer);
                      db.SaveChanges();
                  }));
            }
        }
        private RelayCommand updateCommand;
        public RelayCommand UpdateCommand
        {
            get
            {
                return updateCommand ??
                  (updateCommand = new RelayCommand(obj =>
                  {
                      Buyer buyer = obj as Buyer;
                      buyer.FirstName = window.FirstName.Text;
                      buyer.SecondName = window.SecondName.Text;
                      buyer.LastName = window.LastName.Text;
                      buyer.DateBirth = window.DateBirth.Text;
                      buyer.Passport = window.Passport.Text;
                      buyer.Address = window.Address.Text;
                      db.Entry(buyer).State = EntityState.Modified;
                      db.SaveChanges();
                  }));
            }
        }
        public BuyerViewModel(BuyerWindow window)
        {
            this.window = window;
            BuyersList = new ObservableCollection<Buyer>();
            db.Database.EnsureCreated();
            db.Buyer.Load();
            BuyersList = db.Buyer.Local.ToObservableCollection();
           
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
