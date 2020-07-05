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
        }

        private void btNewOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btStatusOrders_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btSettings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog();
            settingsWindow.Activate();
        }

        private void btStats_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
