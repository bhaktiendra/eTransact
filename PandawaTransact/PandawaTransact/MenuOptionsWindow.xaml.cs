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
        private TransactController transactController;

        // windows
        MenuListWindow menuListWindow;

        public MenuOptionsWindow(TransactController controller)
        {
            InitializeComponent();

            this.transactController = controller;
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
                if (String.IsNullOrEmpty(this.Diskon.Text))
                {
                    this.Diskon.Text = "0";
                }
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

        private void ListMenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (menuListWindow == null)
            {
                menuListWindow = new MenuListWindow(transactController);
                menuListWindow.Closed += DestroyMenuListWindow;
            }

            if (!menuListWindow.IsVisible)
            {
                menuListWindow.Show();
            }
            else
            {
                menuListWindow.Focus();
            }

        }

        private void DestroyMenuListWindow(object sender, EventArgs e)
        {
            menuListWindow = null;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
