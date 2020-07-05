using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace KelnerPlus
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        private List<MenuItem> menuItems;
        Order myOrder;

        public MenuWindow(bool newOrder = false)
        {
            InitializeComponent();
            GridForMenu.Visibility = Visibility.Visible;
            ListBoxMenu.Items.Clear();
            menuItems = Connections.GetMenuItems();
            ArrayList itemsList = new ArrayList();
            foreach (var menuItem in menuItems)
            {
                itemsList.Add(menuItem);
            }
            ListBoxMenu.ItemsSource = itemsList;
            
            
            if (!newOrder)
            {
                Tab6.Visibility = Visibility.Collapsed;
                btAddItem.Visibility = Visibility.Collapsed;
                cbQuantity.Visibility = Visibility.Collapsed;
            }
            else
            {
                for (int i = 1; i < 20; i++)
                {
                    cbQuantity.Items.Add(i);
                }

                cbQuantity.SelectedIndex = 0;
                Tab6.IsSelected = true;
                if (Tab6.IsSelected)
                {
                    GridForMenu.Visibility = Visibility.Collapsed;
                }
                else
                {
                    GridForcart.Visibility = Visibility.Visible;
                }

            }


        }

        private void ListBoxMenu_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = ListBoxMenu.SelectedItem as MenuItem;
            if (selected != null)
            {
                TextBoxTitle.Text = selected.itemName;
                TextBoxDescription.Text = selected.description;
                TextBoxPrice.Text = selected.price.ToString() + " PLN";
                TextBoxIngredients.Text = selected.ingredients;
                CheckBoxActive.IsChecked = selected.isActive;
                CheckBoxLactose.IsChecked = selected.isLactose;
                CheckBoxVege.IsChecked = selected.isVege;
                btAddItem.IsEnabled = selected.isActive;
            }
        }

        private void TabControl1_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoaded && e.Source is TabControl)
            {
                if (Tab6.IsSelected)
                {
                    GridForMenu.Visibility = Visibility.Collapsed;
                    GridForcart.Visibility = Visibility.Visible;
                }
                else
                {
                    GridForMenu.Visibility = Visibility.Visible;
                    GridForcart.Visibility = Visibility.Collapsed;
                }
                
                HideInactiveItems(tabControl1.SelectedIndex + 1);
            }
        }

        private void HideInactiveItems(int categoryId, bool onlyActive = false)
        {
            ListBoxMenu.UpdateLayout();

            foreach (MenuItem item in ListBoxMenu.ItemsSource)
            {
                if (ListBoxMenu.ItemContainerGenerator.ContainerFromItem(item) is ListBoxItem listBoxItem)
                {
                    if ((!item.isActive && onlyActive) || item.categoryId != categoryId)
                        listBoxItem.Visibility = Visibility.Collapsed;
                    else
                        listBoxItem.Visibility = Visibility.Visible;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!Tab6.IsSelected)
            {
                HideInactiveItems(1);
                ListBoxMenu.SelectedIndex = 0;
            }
        }

        private void NewOrder()
        {
            this.myOrder = new Order();
            myOrder.Items = new List<OrderDetails>();
            Tab1.IsSelected = true;
        }

        private void btAddItem_Click(object sender, RoutedEventArgs e)
        {
            var selected = ListBoxMenu.SelectedItem as MenuItem;
            if (selected != null)
            {
                myOrder.TotalPrice += (selected.price * Convert.ToInt32(cbQuantity.Text));
                myOrder.Items.Add(new OrderDetails(selected, Convert.ToInt32(cbQuantity.Text)));
            }
            
            lvOrders.Items.Refresh();
            Tab6.Header = "Koszyk (" + myOrder.TotalPrice + ")";
        }

        private void btStartOrder_Click(object sender, RoutedEventArgs e)
        {
            if (btStartOrder.IsDefault)
            {
                NewOrder();
                lvOrders.ItemsSource = myOrder.Items;
                btStartOrder.IsDefault = false;
                btStartOrder.Content = "Finalizuj zakup";
            }
            else
            {
                myOrder.Note = tbNote.Text;
                AddOrderToDB(myOrder);
                this.DialogResult = true;
                this.Close();
            }

        }

        private void AddOrderToDB(Order order)
        {
            //
        }
    }
}
