using ETransact.Controller;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using Menu = ETransact.Menu;

namespace PandawaTransact
{
    /// <summary>
    /// Interaction logic for MenuOptionsWindow.xaml
    /// </summary>
    public partial class MenuOptionsWindow : Window
    {
        private string ServerName;
        private TransactController transactController;

        public MenuOptionsWindow(string serverName)
        {
            InitializeComponent();

            this.ServerName = serverName;
            this.transactController = new TransactController(this.ServerName);
        }

        private void AddMenuButton_Click(object sender, RoutedEventArgs e)
        {
            if(this.IsValid())
            {
                Menu menu = new Menu();

                menu.Nama = this.Nama.Text;
                menu.Deskripsi = this.Deskripsi.Text;
                menu.Harga = float.Parse(this.Harga.Text, CultureInfo.InvariantCulture.NumberFormat);
                menu.Kategori = "Kategori";
                menu.Metode = "Metode";
                menu.Diskon = float.Parse(this.Diskon.Text, CultureInfo.InvariantCulture.NumberFormat);

                transactController.AddMenu(menu);
            }
            else
            {
                MessageBox.Show("Nama dan harga tidak boleh kosong!");
            }
        }

        private bool IsValid()
        {
            if(String.IsNullOrEmpty(this.Nama.Text) || String.IsNullOrEmpty(this.Harga.Text))
            {
                return false;
            }

            return true;
        }
    }
}
