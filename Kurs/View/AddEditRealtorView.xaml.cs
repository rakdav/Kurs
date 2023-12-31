﻿using Kurs.Model;
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

namespace Kurs.ViewModel
{
    /// <summary>
    /// Логика взаимодействия для AddEditRealtorView.xaml
    /// </summary>
    public partial class AddEditRealtorView : Window
    {
        public Realtor Realtor { get; private set; }
        public AddEditRealtorView(Realtor realtor)
        {
            InitializeComponent();
            Realtor=realtor;
            DataContext = Realtor;
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
