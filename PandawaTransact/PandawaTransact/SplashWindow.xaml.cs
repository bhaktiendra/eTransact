using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
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
    /// Interaction logic for SplashWindow.xaml
    /// </summary>
    public partial class SplashWindow : Window
    {
        public SplashWindow()
        {
            InitializeComponent();
        }

        private void PopulateServers()
        {
            DataTable dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            foreach (DataRow dr in dt.Rows)
            {
                ServerList.Items.Add(string.Concat(dr["ServerName"], "\\", dr["InstanceName"]));
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            this.PopulateServers();
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            // need to validate too :(
            MainWindow main = new MainWindow(ServerList.Text);
            main.Show();

            this.Close();
        }


    }
}
