using System;
using System.Collections;
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
    /// Interaction logic for NewOrderWindow.xaml
    /// </summary>
    public partial class NewOrderWindow : Window
    {
        public NewOrderWindow()
        {
            InitializeComponent();
            orderItems.Items.Clear();
            List<MenuItem> menuItems = Connections.GetMenuItems();

            ArrayList itemsList = new ArrayList();
            foreach (var menuItem in menuItems)
            {
                itemsList.Add(menuItem);
            }

            orderItems.ItemsSource = itemsList;

            HideInactiveItems();
        }

        private void HideInactiveItems()
        {
            foreach (MenuItem item in orderItems.ItemsSource)
            {
                if (orderItems.ItemContainerGenerator.ContainerFromItem(item) is ListBoxItem listBoxItem)
                {
                    if (!item.isActive)
                        listBoxItem.Visibility = Visibility.Collapsed;
                    else
                        listBoxItem.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
