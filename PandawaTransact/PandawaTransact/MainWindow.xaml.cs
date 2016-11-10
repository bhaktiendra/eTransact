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
using ETransact;

namespace PandawaTransact
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TransactController controller = new TransactController();

        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ETransact.Menu menu = new ETransact.Menu();

            menu.Id = 1;
            menu.Nama = "Test";
            menu.Harga = 2000;
            menu.Diskon = 50;
            menu.Deskripsi = "test desc";
            menu.Metode = "metode";
            menu.Kategori = "test";

            controller.AddMenu(menu);
        }
    }
}
