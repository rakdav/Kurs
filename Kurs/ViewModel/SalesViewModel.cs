using Kurs.Model;
using Kurs.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Kurs.ViewModel
{
    public class SalesViewModel : INotifyPropertyChanged
    {
        private SalesView window;
        private Sale selectedSale;
        ModelContext db = new ModelContext();
        public ObservableCollection<Sale> SaleList { get; set; }
        public ObservableCollection<Buyer> BuyerList { get; set; }
        public ObservableCollection<RealEstate> RealEstateList { get; set; }
        public ObservableCollection<SalesMan> SaleManList { get; set; }
        public ObservableCollection<Realtor> RealtorList { get; set; }
        public Sale SelectedSale
        {
            get { return selectedSale; }
            set
            {
                selectedSale = value;
                OnPropertyChanged("SelectedSale");
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
                      Sale sale = new Sale();
                      sale.ID_Buyer = (window.cbBuyer.SelectedItem as Buyer).ID_Buyer;
                      sale.ID_RealState = (window.cbRealState.SelectedItem as RealEstate).ID_Estate;
                      sale.ID_SalesMan = (window.cbSalesMan.SelectedItem as SalesMan).id_SalesMan;
                      sale.ID_Realtor = (window.cbRealtor.SelectedItem as Realtor).id_realtor;
                      sale.Price = decimal.Parse(window.Price.Text);
                      sale.Date = window.date.Text;
                      db.Sale.Add(sale);
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
                      Sale sale = obj as Sale;
                      SaleList.Remove(sale);
                      if (sale == null) return;
                      db.Sale.Remove(sale);
                      db.SaveChanges();
                  }));
            }
        }
        public SalesViewModel(SalesView window)
        {
            this.window = window;
            db.Database.EnsureCreated();
            db.Sale.Load();
            db.Realtor.Load();
            db.SalesMan.Load();
            db.Buyer.Load();
            db.RealEstate.Load();
            BuyerList=db.Buyer.Local.ToObservableCollection();
            SaleList = db.Sale.Local.ToObservableCollection();
            RealtorList=db.Realtor.Local.ToObservableCollection();
            SaleManList = db.SalesMan.Local.ToObservableCollection();
            RealEstateList = db.RealEstate.Local.ToObservableCollection();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
