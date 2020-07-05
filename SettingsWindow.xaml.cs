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
            GetSettings();

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
                btSaveSettings.IsEnabled = true;
            }
            else
            {
                btSaveSettings.IsEnabled = false;
            }
        }

        private async void btCheckCfg_Click(object sender, RoutedEventArgs e)
        {

            btCheckCfg.IsEnabled = false;
            Task<bool> task = new Task<bool>(Connections.IsServerConnected);

            ProgressBarSettings.IsIndeterminate = true;
            task.Start();

            if (await task)
            {
                this.DialogResult = true;
                this.Close();
            }

            ProgressBarSettings.IsIndeterminate = false;
            btCheckCfg.IsEnabled = true;
        }

        

        private void BtSaveSettings_OnClick(object sender, RoutedEventArgs e)
        {
            if (tbDBName.IsEnabled)
            {
                SaveSettings();
                tbDBServer.IsEnabled = false;
                tbDBName.IsEnabled = false;
                tbDBUser.IsEnabled = false;
                pbDBPass.IsEnabled = false;
                btSaveSettings.Content = "Edytuj";
                btCheckCfg.IsEnabled = true;
            }
            else
            {
                tbDBServer.IsEnabled = true;
                tbDBName.IsEnabled = true;
                tbDBUser.IsEnabled = true;
                pbDBPass.IsEnabled = true;
                pbDBPass.Password = "";
                btSaveSettings.Content = "Zapisz";
                btSaveSettings.IsEnabled = false;
                btCheckCfg.IsEnabled = false;
            }
        }

        public void GetSettings()
        {
            tbDBServer.Text = Properties.Settings.Default.ServerName.ToString();
            tbDBName.Text = Properties.Settings.Default.DBName.ToString();
            tbDBUser.Text = Properties.Settings.Default.DBUserName.ToString();
            pbDBPass.Password = Properties.Settings.Default.DBPassword.ToString();
        }

        public void SaveSettings()
        {

            Properties.Settings.Default.ServerName = tbDBServer.Text;
            Properties.Settings.Default.DBName = tbDBName.Text;
            Properties.Settings.Default.DBUserName = tbDBUser.Text;
            Properties.Settings.Default.DBPassword = pbDBPass.Password;
            Properties.Settings.Default.Save();
        }
    }
}
