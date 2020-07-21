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
    public partial class MenuWindow
    {
        public List<MenuItem> MenuItems;
        private Order _myOrder;

        /// <summary>
        /// Inicjalizacja naszego okna Menu
        /// </summary>
        /// <param name="newOrder"> parametr prawda/fałsz czy mają być dostępne opcje składania zamówienia</param>
        public MenuWindow(bool newOrder = false)
        {
            InitializeComponent();
            GridForMenu.Visibility = Visibility.Visible;
            ListBoxMenu.Items.Clear();
            MenuItems = Connections.GetMenuItems();
            ArrayList itemsList = new ArrayList();
            foreach (var menuItem in MenuItems)
            {
                itemsList.Add(menuItem);
            }
            ListBoxMenu.ItemsSource = itemsList;
            
            
            if (!newOrder)
            {
                Tab6.Visibility = Visibility.Collapsed;
                BtAddItem.Visibility = Visibility.Collapsed;
                CbQuantity.Visibility = Visibility.Collapsed;
                LQuantity.Visibility = Visibility.Collapsed;
            }
            else
            {
                for (int i = 1; i < 20; i++)
                {
                    CbQuantity.Items.Add(i);
                }

                CbQuantity.SelectedIndex = 0;
                Tab6.IsSelected = true;
                foreach (var tabItem in TabControl1.Items)
                {
                    ((TabItem) tabItem).IsEnabled = false;
                }

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

        /// <summary>
        /// Zdarzenie do wypełniania naszych textBoxów gdy wybierzemy inny element z ListBoxMenu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBoxMenu_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxMenu.SelectedItem is MenuItem selected)
            {
                TextBoxTitle.Text = selected.ItemName;
                TextBoxDescription.Text = selected.Description;
                TextBoxPrice.Text = selected.Price.ToString() + " PLN";
                TextBoxIngredients.Text = selected.Ingredients;
                CheckBoxActive.IsChecked = selected.IsActive;
                CheckBoxLactose.IsChecked = selected.IsLactose;
                CheckBoxVege.IsChecked = selected.IsVege;
                BtAddItem.IsEnabled = selected.IsActive;
            }
        }

        /// <summary>
        /// Zdarzenie ukrywające/pokazujące koszyk podczas przełączania między kartami TabControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                
                HideInactiveItems(TabControl1.SelectedIndex + 1);
            }
        }

        /// <summary>
        /// Metoda filtrująca nasze elementy w menu
        /// </summary>
        /// <param name="categoryId">według jakiej kategorii sortować</param>
        /// <param name="onlyActive">czy pokazać tylko aktywne elementy menu</param>
        private void HideInactiveItems(int categoryId, bool onlyActive = false)
        {
            ListBoxMenu.UpdateLayout();

            foreach (MenuItem item in ListBoxMenu.ItemsSource)
            {
                if (ListBoxMenu.ItemContainerGenerator.ContainerFromItem(item) is ListBoxItem listBoxItem)
                {
                    if ((!item.IsActive && onlyActive) || item.CategoryId != categoryId)
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

        /// <summary>
        /// Utworzenie instancji dla naszego nowego zamówienia
        /// </summary>
        private void NewOrder()
        {
            this._myOrder = new Order();
            _myOrder.Items = new List<OrderDetails>();
            Tab1.IsSelected = true;

            foreach (var tabItem in TabControl1.Items)
            {
                ((TabItem) tabItem).IsEnabled = true;
            }
        }

        /// <summary>
        /// Zdarzenie dodające nasz przedmiot do koszyka
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAddItem_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxMenu.SelectedItem is MenuItem selected)
            {
                // ilosc musi byc zaokraglona do 2 miejsc po przecinku, poniewaz konwersja  np. tekstu 7 na double da wynik 7.00000.....1
                _myOrder.TotalPrice += (selected.Price * Math.Round(Convert.ToDouble(CbQuantity.Text), 2));
                _myOrder.Items.Add(new OrderDetails(selected, Convert.ToInt32(CbQuantity.Text)));
            }
            
            LvOrders.Items.Refresh();
            Tab6.Header = "Koszyk (" + _myOrder.TotalPrice + ")";
        }

        /// <summary>
        /// Przycisk rozpoczynania oraz kończenia zamówienia wywołuje poniższe zdarzenie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btStartOrder_Click(object sender, RoutedEventArgs e)
        {
            if (BtStartOrder.IsDefault)
            {
                NewOrder();
                LvOrders.ItemsSource = _myOrder.Items;
                BtStartOrder.IsDefault = false;
                BtStartOrder.Content = "Finalizuj zakup";
            }
            else
            {
                _myOrder.Note = TbNote.Text;
                _myOrder.Status = 1;
                DateTime myDateTime = DateTime.Now;
                _myOrder.OrderTime = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                AddOrderToDB(_myOrder);
                
                this.DialogResult = true;
                this.Close();
            }

        }

        /// <summary>
        ///  Odpowiada za przesłanie zamówienia oraz szczegółów zamówienia do bazy
        /// </summary>
        /// <param name="order">Nasz obiekt order, który zostanie zapisany w bazie</param>
        private void AddOrderToDB(Order order)
        {
            
            string insertOrder = $@"INSERT INTO [dbo].[Orders]([order_status],[order_time],[ready_time],[total_price],[note])VALUES({order.Status},'{order.OrderTime}', '{order.ReadyTime}',{order.TotalPrice},'{order.Note}')";
            Connections.ExecuteSqlCommand(insertOrder);
            var lastOrderId = Convert.ToInt32(Connections.ExecuteSqlCommand("SELECT IDENT_CURRENT('Orders');"));

            string insertOrderDetails = "";
            foreach (OrderDetails orderDetails in order.Items)
            {
                insertOrderDetails += $@"INSERT INTO [dbo].[DetailsOrder]([order_id], [menu_item_id],[quantity])VALUES({lastOrderId},{orderDetails.MenuItemId},{orderDetails.Quantity});";
            }
            Connections.ExecuteSqlCommand(insertOrderDetails);

        }

        /// <summary>
        /// zdarzenie wywoływane gdy użytkownik kliknie Aktywuj/deaktywuj na liście menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            if (ListBoxMenu.SelectedItem is MenuItem selected)
            {
                selected.IsActive = !selected.IsActive;
                Connections.ExecuteSqlCommand($@"UPDATE MenuItems SET active= {Convert.ToInt32(selected.IsActive)} WHERE id= {selected.Id};"); 
                this.Close();
            }
        }
    }
}
