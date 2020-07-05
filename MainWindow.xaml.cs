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
            lbVersion.Content = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            // check if there is connection with database
            Connect();


        }

        private async void Connect()
        {
            Task<bool> task = new Task<bool>(Connections.IsServerConnected);

            task.Start();

            if (await task)
            {
                tbConnectionStatus.Foreground = Brushes.ForestGreen;
                tbConnectionStatus.Text = "Połączono z bazą danych.";
                btNewOrder.IsEnabled = true;
                btMenu.IsEnabled = true;
                btStats.IsEnabled = true;
                btStatusOrders.IsEnabled = true;
            }
            else
            {
                tbConnectionStatus.Text = "Brak połączenia z bazą danych. Sprawdź ustawienia.";
                MessageBox.Show("Brak połączenia z bazą danych. Sprawdź ustawienia.");
                btNewOrder.IsEnabled = false;
                btMenu.IsEnabled = false;
                btStats.IsEnabled = false;
                btStatusOrders.IsEnabled = false;
            }

            btSettings.IsEnabled = true;



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
            btNewOrder.IsEnabled = false;
            btMenu.IsEnabled = false;
            btStats.IsEnabled = false;
            btStatusOrders.IsEnabled = false;

            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog();
            settingsWindow.Activate();
            if (settingsWindow.DialogResult == true)
            {
                tbConnectionStatus.Foreground = Brushes.ForestGreen;
                tbConnectionStatus.Text = "Połączono z bazą danych.";
                MessageBox.Show("Ustanowiono połączenie z bazą!");
                btNewOrder.IsEnabled = true;
                btMenu.IsEnabled = true;
                btStats.IsEnabled = true;
                btStatusOrders.IsEnabled = true;
            }
            else
            {
                tbConnectionStatus.Foreground = Brushes.Red;
                tbConnectionStatus.Text = "Ładowanie ustawień...";
                Connect();
            }
        }

        private void btStats_Click(object sender, RoutedEventArgs e)
        {
            var myQuery = Connections.ExecuteSqlCommand("select * FROM test");
        }
    }
}
