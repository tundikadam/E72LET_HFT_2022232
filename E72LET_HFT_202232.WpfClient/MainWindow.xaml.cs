﻿using System;
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

namespace E72LET_HFT_202232.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Gclick(object sender, RoutedEventArgs e)
        {
            Games g = new Games();
        }

        private void Minclick(object sender, RoutedEventArgs e)
        {
            MinimalSystemRequries min=new MinimalSystemRequries(); ;
        }
    }
}
