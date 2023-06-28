using Kurs.Model;
using Kurs.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Kurs.View
{
    /// <summary>
    /// Логика взаимодействия для AddEditSaleMan.xaml
    /// </summary>
    public partial class AddEditSaleMan : Window
    {
        public SalesMan SaleMan { get; private set; }
        public AddEditSaleMan(SalesMan saleMan)
        {
            InitializeComponent();
            SaleMan = saleMan;
            DataContext = SaleMan;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
