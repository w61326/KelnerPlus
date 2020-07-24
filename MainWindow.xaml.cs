using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace KelnerPlus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // pobranie wersji programu z ustawień projektu
            LbVersion.Content = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            // sprawdzenie czy jest połączenie z bazą danych
            Connect();


        }

        private async void Connect()
        {
            Task<bool> task = new Task<bool>(Connections.IsServerConnected);

            // urochomienie procesu połączenia z bazą
            task.Start();


            // sprawdzenie czy połączenie z bazą aktywne
            if (await task)
            {
                TbConnectionStatus.Foreground = Brushes.ForestGreen;
                TbConnectionStatus.Text = "Połączono z bazą danych.";
                BtNewOrder.IsEnabled = true;
                BtMenu.IsEnabled = true;
                BtStats.IsEnabled = true;
                BtStatusOrders.IsEnabled = true;
            }
            else
            {
                TbConnectionStatus.Text = "Brak połączenia z bazą danych. Sprawdź ustawienia.";
                MessageBox.Show("Brak połączenia z bazą danych. Sprawdź ustawienia.");
                BtNewOrder.IsEnabled = false;
                BtMenu.IsEnabled = false;
                BtStats.IsEnabled = false;
                BtStatusOrders.IsEnabled = false;
            }

            BtSettings.IsEnabled = true;



        }

        private void btNewOrder_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow newOrderWindow = new MenuWindow(true);
            newOrderWindow.ShowDialog();
            newOrderWindow.Activate();
            if (newOrderWindow.DialogResult == true)
            {
                MessageBox.Show("Zamówienie trafiło do realizacji");
            }
        }

        private void btStatusOrders_Click(object sender, RoutedEventArgs e)
        {
            StatusWindow newStatusWindow = new StatusWindow();
            newStatusWindow.ShowDialog();
            newStatusWindow.Activate();
        }

        private void btMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.ShowDialog();
            menuWindow.Activate();
        }

        private void btSettings_Click(object sender, RoutedEventArgs e)
        {
            BtNewOrder.IsEnabled = false;
            BtMenu.IsEnabled = false;
            BtStats.IsEnabled = false;
            BtStatusOrders.IsEnabled = false;

            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog();
            settingsWindow.Activate();
            if (settingsWindow.DialogResult == true)
            {
                TbConnectionStatus.Foreground = Brushes.ForestGreen;
                TbConnectionStatus.Text = "Połączono z bazą danych.";
                MessageBox.Show("Ustanowiono połączenie z bazą!");
                BtNewOrder.IsEnabled = true;
                BtMenu.IsEnabled = true;
                BtStats.IsEnabled = true;
                BtStatusOrders.IsEnabled = true;
            }
            else
            {
                TbConnectionStatus.Foreground = Brushes.Red;
                TbConnectionStatus.Text = "Ładowanie ustawień...";
                Connect();
            }
        }

        /// <summary>
        /// metoda eksportująca statystyki
        /// </summary>
        private async void ExportStats()
        {
            this.IsEnabled = false;
            TbConnectionStatus.Foreground = Brushes.DeepSkyBlue;
            TbConnectionStatus.Text = "Eksportowanie statystyk...";

            await Task.Delay(2000);

            this.IsEnabled = true;
            TbConnectionStatus.Foreground = Brushes.ForestGreen;
            TbConnectionStatus.Text = "Połączono z bazą danych.";

        }

        /// <summary>
        /// zdarzenie po kliknięciu eksportuj statystyki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btStats_Click(object sender, RoutedEventArgs e)
        {
            ExportStats();
        }
    }
}
