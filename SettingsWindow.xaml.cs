using System.Threading.Tasks;
using System.Windows;
using KelnerPlus.Properties;

namespace KelnerPlus
{
    /// <summary>
    /// Okno wprowadzania ustawień połączenia do bazy
    /// </summary>
    public partial class SettingsWindow
    {

        public SettingsWindow()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            GetSettings();

        }

        /// <summary>
        /// Zdarzenie wywoływane podczas edycji któregoś z textboxu ustawień
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigEdit(object sender, RoutedEventArgs e)
        {
            // sprawdzenie czy okno nadal się ładuje
            if (!IsLoaded)
            {
                return;
            }

            // sprawdzenie czy textboxy ustawień nie są puste
            if (!string.IsNullOrWhiteSpace(TbDbServer.Text) &&
                !string.IsNullOrWhiteSpace(TbDbName.Text) &&
                !string.IsNullOrWhiteSpace(TbDbUser.Text) &&
                !string.IsNullOrWhiteSpace(PbDbPass.Password))
            {
                BtSaveSettings.IsEnabled = true;
            }
            else
            {
                BtSaveSettings.IsEnabled = false;
            }
        }

        /// <summary>
        /// Zdarzenie po kliknięciu "Sprawdź połączenie"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btCheckCfg_Click(object sender, RoutedEventArgs e)
        {

            BtCheckCfg.IsEnabled = false;
            Task<bool> task = new Task<bool>(Connections.IsServerConnected);

            ProgressBarSettings.IsIndeterminate = true;
            task.Start();

            if (await task)
            {
                DialogResult = true;
                Close();
            }

            ProgressBarSettings.IsIndeterminate = false;
            BtCheckCfg.IsEnabled = true;
        }

        

        /// <summary>
        /// Zdarzenie po kliknięciu zapisz/edytuj ustawienia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtSaveSettings_OnClick(object sender, RoutedEventArgs e)
        {
            if (TbDbName.IsEnabled)
            {
                SaveSettings();
                TbDbServer.IsEnabled = false;
                TbDbName.IsEnabled = false;
                TbDbUser.IsEnabled = false;
                PbDbPass.IsEnabled = false;
                BtSaveSettings.Content = "Edytuj";
                BtCheckCfg.IsEnabled = true;
            }
            else
            {
                TbDbServer.IsEnabled = true;
                TbDbName.IsEnabled = true;
                TbDbUser.IsEnabled = true;
                PbDbPass.IsEnabled = true;
                PbDbPass.Password = "";
                BtSaveSettings.Content = "Zapisz";
                BtSaveSettings.IsEnabled = false;
                BtCheckCfg.IsEnabled = false;
            }
        }

        /// <summary>
        /// Załadowanie ustawień do textboxów
        /// </summary>
        public void GetSettings()
        {
            TbDbServer.Text = Settings.Default.ServerName;
            TbDbName.Text = Settings.Default.DBName;
            TbDbUser.Text = Settings.Default.DBUserName;
            PbDbPass.Password = Settings.Default.DBPassword;
        }

        /// <summary>
        /// Zapis ustawień do bazy danych
        /// </summary>
        public void SaveSettings()
        {
            Settings.Default.ServerName = TbDbServer.Text;
            Settings.Default.DBName = TbDbName.Text;
            Settings.Default.DBUserName = TbDbUser.Text;
            Settings.Default.DBPassword = PbDbPass.Password;
            Settings.Default.Save();
        }
    }
}
