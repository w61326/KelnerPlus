using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace KelnerPlus
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            this.Owner = App.Current.MainWindow;
        }


        private void ConfigEdit(object sender, RoutedEventArgs e)
        {
            // do not check if window is still loading
            if (!this.IsLoaded)
            {
                return;
            }

            // check if user set config and make Check connection button enabled
            if (!string.IsNullOrWhiteSpace(tbDBServer.Text) &&
                !string.IsNullOrWhiteSpace(tbDBName.Text) &&
                !string.IsNullOrWhiteSpace(tbDBUser.Text) &&
                !string.IsNullOrWhiteSpace(pbDBPass.Password))
            {
                btCheckCfg.IsEnabled = true;
            }
            else
            {
                btCheckCfg.IsEnabled = false;
            }
        }

        private async void btCheckCfg_Click(object sender, RoutedEventArgs e)
        {
            Task<bool> task = new Task<bool>(IsServerConnected);
            ProgressBarSettings.IsIndeterminate = true;
            task.Start();

            if (await task)
            {
                ProgressBarSettings.IsIndeterminate = false;
                btSaveSettings.IsEnabled = true;
            }
            
        }

        /// <summary>
        /// Test that the server is connected
        /// </summary>
        /// <param name="connectionString">The connection string</param>
        /// <returns>true if the connection is opened</returns>
        private static bool IsServerConnected()
        {
            string dbServer, dbName, dbUser, dbPass;
            Thread.Sleep(2000);
            //string connectionString = string.Format("server={0};database={1};uid={2};password={3};", dbServer, dbName, dbUser, dbPass);
            string connectionString = "server=DESKTOP;database=kitchen;uid=sa;password=test;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    connection.Close();
                    return true;
                }
                catch (SqlException ex)
                {
                    StringBuilder errorMessages = new StringBuilder();
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                                             "Message: " + ex.Errors[i].Message + "\n" +
                                             "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                                             "Source: " + ex.Errors[i].Source + "\n" +
                                             "Procedure: " + ex.Errors[i].Procedure + "\n");
                    }

                    MessageBox.Show(errorMessages.ToString());
                    return false;
                }
            }
        }
    }
}
