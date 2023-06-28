using Microsoft.Data.Sqlite;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Drawing.Imaging;
using Kurs.ViewModel;

namespace Kurs.View
{
    /// <summary>
    /// Логика взаимодействия для RealEstateWindow.xaml
    /// </summary>
    public partial class RealEstateView : Window
    {
        private string ImageFileName { get; set; }
        public RealEstateView()
        {
            InitializeComponent();
            DataContext = new RealEstateViewModel(this);
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog ofd = new OpenFileDialog();
        //    ofd.Filter = "*.jpg|*.jpg";
        //    if(ofd.ShowDialog()==true)
        //    {
        //        BitmapImage myBitmapImage = new BitmapImage();
        //        ImageFileName = ofd.FileName;
        //        myBitmapImage.BeginInit();
        //        myBitmapImage.UriSource = new Uri(ofd.FileName);
        //        myBitmapImage.DecodePixelWidth = 200;
        //        myBitmapImage.EndInit();
        //        ImageRealEstate.Source = myBitmapImage;
                
        //    }
        //}

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    using (var connection = new SqliteConnection("Data Source=RealEstate.db"))
        //    {
        //        connection.Open();

        //        SqliteCommand command = new SqliteCommand();
        //        command.Connection = connection;
        //        string base64 = Convert.ToBase64String(File.ReadAllBytes(ImageFileName));
        //        byte[] buffer = Convert.FromBase64String(base64);
        ////    }
        //}
    }
}
