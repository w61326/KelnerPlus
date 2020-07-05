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
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
            

            List<MenuItem> menuItems = Connections.GetMenuItems();
            ArrayList itemsList = new ArrayList();
            foreach (var menuItem in menuItems)
            {
                itemsList.Add(menuItem);
            }
            

            ListBoxSoups.ItemsSource = itemsList;

        }

        private void ListBoxSoups_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = ListBoxSoups.SelectedItem as MenuItem;
            if (selected != null)
            {
            }
        }

        private void TabControl1_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (IsLoaded && e.Source is TabControl)
            {
                if (TabSoups.IsSelected)
                {
                    foreach (MenuItem item in ListBoxSoups.ItemsSource)
                    {
                        if (!item.isActive || item.categoryId != 1)
                        {
                            ListBoxItem listBoxItem = ListBoxSoups.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;
                            if (listBoxItem != null) listBoxItem.Visibility = Visibility.Collapsed;
                        }


                    }
                }
                    
            }
        }
    }
}
