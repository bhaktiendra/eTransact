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
using System.Windows.Shapes;

namespace PandawaTransact
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ExitPopup : Window
    {
        public ExitPopup()
        {
            InitializeComponent();
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}
