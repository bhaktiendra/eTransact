using ETransact.Controller;
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
using System.Windows.Shapes;

namespace PandawaTransact
{
    /// <summary>
    /// Interaction logic for MenuListWindow.xaml
    /// </summary>
    public partial class MenuListWindow : Window
    {
        private TransactController transactController;

        public MenuListWindow(TransactController controller)
        {
            InitializeComponent();

            this.transactController = controller;
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var menus = this.transactController.ReadMenu();

            var grid = sender as DataGrid;
            grid.ItemsSource = menus;
        }
    }
}
