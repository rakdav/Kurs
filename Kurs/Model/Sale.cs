using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace Kurs.Model
{
    public class Sale : INotifyPropertyChanged
    {
        [Key]
        public int ID_Sale { get; set; }
        private int Id_Buyer;
        public int ID_Buyer
        {
            get { return Id_Buyer; }
            set { 
                Id_Buyer = value;
                OnPropertyChanged("ID_Buyer");
            }
        }
        private int Id_RealState;
        public int ID_RealState
        {
            get { return Id_RealState; }
            set
            {
                Id_RealState = value;
                OnPropertyChanged("ID_RealState");
            }
        }
        private int Id_Realtor;
        public int ID_Realtor
        {
            get { return Id_Realtor; }
            set
            {
                Id_Realtor = value;
                OnPropertyChanged("ID_Realtor");
            }
        }
        private int Id_SalesMan;
        public int ID_SalesMan
        {
            get { return Id_SalesMan; }
            set
            {
                Id_SalesMan = value;
                OnPropertyChanged("ID_SalesMan");
            }
        }
        private decimal price;
        public decimal Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }
        private string date;
        public string Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
