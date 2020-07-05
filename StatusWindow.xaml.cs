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
using System.Windows.Shapes;

namespace KelnerPlus
{
    /// <summary>
    /// Interaction logic for StatsWindow.xaml
    /// </summary>
    public partial class StatusWindow : Window
    {
        public List<Order> orders;
        public StatusWindow()
        {
            InitializeComponent();

            orders = new List<Order>();
            for (int i = 0; i < 5; i++)
            {
                Order myOrder = new Order();
                myOrder.Id = i;
                myOrder.Note = "Zamowienie nr " + i;
                myOrder.OrderTime = "2008-11-11 13:23:44";
                myOrder.Status = 1;
                orders.Add(myOrder);
            }

            lvStatuses.ItemsSource = orders;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvStatuses.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Id");
            view.GroupDescriptions.Add(groupDescription);

        }

        private void btFinishOrder_Click(object sender, RoutedEventArgs e)
        {
            if (lvStatuses.SelectedValue == null)
            {
                MessageBox.Show("Najpierw wybierz zamowienie.");
            }
            else
            {
                if (orders[lvStatuses.SelectedIndex].Status > 1)
                {
                    MessageBox.Show("To zamówienie zostało już zakończone.");
                    return;
                }
                
                orders[lvStatuses.SelectedIndex].Status = 2;
                DateTime myDateTime = DateTime.Now;
                orders[lvStatuses.SelectedIndex].ReadyTime = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                lvStatuses.Items.Refresh();

            }
        }
    }
}
