using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            ButtonSelectDatabase.IsEnabled = false;
        }

        private void PopulateServers()
        {
            DataTable dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            foreach (DataRow dr in dt.Rows)
            {
                this.Dispatcher.Invoke(() =>
                {
                    ServerList.Items.Add(string.Concat(dr["ServerName"], "\\", dr["InstanceName"]));
                });
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            WaitingPopUp popup = new WaitingPopUp();
            popup.Show();
            IsEnabled = false;

            BackgroundWorker bw = new BackgroundWorker();

            // this allows our worker to report progress during work
            bw.WorkerReportsProgress = true;

            // what to do in the background thread
            bw.DoWork += new DoWorkEventHandler(
            delegate (object o, DoWorkEventArgs args)
            {
                PopulateServers();
            });

            // what to do when progress changed (update the progress bar for example)
            //bw.ProgressChanged += new ProgressChangedEventHandler(
            //delegate (object o, ProgressChangedEventArgs args)
            //{
            //    label1.Text = string.Format("{0}% Completed", args.ProgressPercentage);
            //});

            // what to do when worker completes its task (notify the user)
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                delegate (object o, RunWorkerCompletedEventArgs args)
                {
                    popup.Close();
                    bw.Dispose();

                    IsEnabled = true;
                });

            bw.RunWorkerAsync();
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow(ServerList.Text);
            main.Show();

            this.Close();
        }

        private void ServerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ServerList.SelectedIndex != -1)
            {
                ButtonSelectDatabase.IsEnabled = true;
            }
            else
            {
                ButtonSelectDatabase.IsEnabled = false;
            }
        }
    }
}
