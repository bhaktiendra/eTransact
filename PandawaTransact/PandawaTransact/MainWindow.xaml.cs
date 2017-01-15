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
using ETransact.Controller;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace PandawaTransact
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TransactController transactController;
        private string ServerName;

        // windows
        private MenuOptionsWindow menuOptionsWindow;

        public MainWindow(string serverName)
        {
            InitializeComponent();

            // initialize the controller
            this.ServerName = serverName;
            this.transactController = new TransactController(this.ServerName);

            // initialize possible windows
            menuOptionsWindow = new MenuOptionsWindow(this.ServerName);
        }

        private void MenuOptionsButton_Click(object sender, RoutedEventArgs e)
        {
            if (!menuOptionsWindow.IsVisible)
            {
                menuOptionsWindow.Show();
            }
            else
            {
                menuOptionsWindow.Focus();
            }
        }

        
    }
}
