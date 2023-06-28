using Kurs.View;
using Kurs.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kurs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SalesView : Window
    {
        public SalesView()
        {
            InitializeComponent();
            DataContext = new SalesViewModel(this);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            BuyerWindow buyerWindow = new BuyerWindow();
            buyerWindow.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            RealEstateView real=new RealEstateView();
            real.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            RialtorWindow realtor=new RialtorWindow();
            realtor.Show();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            SalesManWindow salesMan=new SalesManWindow();
            salesMan.Show();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
