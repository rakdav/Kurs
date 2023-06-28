using Kurs.Model;
using Kurs.View;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using System.Xml;

namespace Kurs.ViewModel
{
    class RealEstateViewModel : INotifyPropertyChanged
    {
        private RealEstateView window;
        private RealEstate selectedRealEstate;
        ModelContext db = new ModelContext();
        private string ImageFileName { get; set; }
        public ObservableCollection<RealEstate> RealEstateList { get; set; }
        public RealEstate SelectedRealEstate
        {
            get { return selectedRealEstate; }
            set
            {
                selectedRealEstate = value;
                OnPropertyChanged("SelectedRealEstate");
            }
        }

        public RealEstateViewModel(RealEstateView window)
        {
            this.window = window;
            RealEstateList = new ObservableCollection<RealEstate>();
            db.Database.EnsureCreated();
            db.RealEstate.Load();
            RealEstateList = db.RealEstate.Local.ToObservableCollection();
        }

        private RelayCommand loadCommand;
        public RelayCommand LoadCommand
        {
            get
            {
                return loadCommand ??
                  (loadCommand = new RelayCommand(obj =>
                  {
                      OpenFileDialog ofd = new OpenFileDialog();
                      ofd.Filter = "*.jpg|*.jpg|*.bmp|*.bmp";
                      if (ofd.ShowDialog() == true)
                      {
                          BitmapImage myBitmapImage = new BitmapImage();
                          ImageFileName = ofd.FileName;
                          myBitmapImage.BeginInit();
                          myBitmapImage.UriSource = new Uri(ofd.FileName);
                          myBitmapImage.DecodePixelWidth = 200;
                          myBitmapImage.EndInit();
                          window.ImageRealEstate.Source = myBitmapImage;

                      }
                  }));
            }
        }
        private RelayCommand insertCommand;
        public RelayCommand InsertCommand
        {
            get
            {
                return insertCommand ??
                  (insertCommand = new RelayCommand(obj =>
                  {
                      RealEstate realEstate = new RealEstate();
                      realEstate.Region = window.region.Text;
                      realEstate.Street=window.street.Text;
                      realEstate.Department=window.department.Text;
                      realEstate.House=window.house.Text;
                      realEstate.Image = Convert.ToBase64String(File.ReadAllBytes(ImageFileName));
                      db.RealEstate.Add(realEstate);
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
                  (removeCommand = new RelayCommand(selectedItem =>
                  {
                      // получаем выделенный объект
                      RealEstate user = selectedItem as RealEstate;
                      if (user == null) return;
                      db.RealEstate.Remove(user);
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
                  (updateCommand = new RelayCommand(selectedItem =>
                  {
                      // получаем выделенный объект
                      RealEstate realEstate = selectedItem as RealEstate;
                      if (realEstate == null) return;
                      realEstate.Region = window.region.Text;
                      realEstate.Street = window.street.Text;
                      realEstate.Department = window.department.Text;
                      realEstate.House = window.house.Text;
                      realEstate.Image = Convert.ToBase64String(File.ReadAllBytes(ImageFileName));
                      db.Entry(realEstate).State = EntityState.Modified;
                      db.SaveChanges();
                  }));
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
