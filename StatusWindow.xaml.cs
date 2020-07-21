using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace KelnerPlus
{
    /// <summary>
    /// Okno statusu zamówień
    /// </summary>
    public partial class StatusWindow
    {
        public List<Order> Orders;
        public StatusWindow()
        {
            InitializeComponent();

            Orders = Connections.GeOrders();
            ArrayList orderList = new ArrayList(); 
            
              foreach (var order in Orders)
              {
                  order.Items = Connections.GetDetails(order.Id);
                orderList.Add(order);
            }
             

            LvStatuses.ItemsSource = orderList;

            // Grupowanie według ID (żeby ładniej wyglądało)
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(LvStatuses.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Id");
            view.GroupDescriptions.Add(groupDescription);

        }

        /// <summary>
        /// Zakończenie danego zamówienia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btFinishOrder_Click(object sender, RoutedEventArgs e)
        {
            if (LvStatuses.SelectedValue == null)
            {
                MessageBox.Show("Najpierw wybierz zamowienie.");
            }
            else
            {
                Order myOrder = Orders[LvStatuses.SelectedIndex];

                if (myOrder.Status > 1)
                {
                    MessageBox.Show("To zamówienie zostało już zakończone.");
                    return;
                }
                
                myOrder.Status = 2;
                DateTime myDateTime = DateTime.Now;
                myOrder.ReadyTime = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                Connections.ChangeStatus(myOrder.Id, myOrder.ReadyTime);
                LvStatuses.Items.Refresh();

            }
        }

        /// <summary>
        /// Wyświetlenie szczegółów zamówienia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowDetails_OnClick(object sender, RoutedEventArgs e)
        {
            if (LvStatuses.SelectedValue == null)
            {
                MessageBox.Show("Najpierw wybierz zamowienie.");
            }
            else
            {
                Order myOrder = Orders[LvStatuses.SelectedIndex];
                StringBuilder msgDetail = new StringBuilder();
                msgDetail.Append("Zamówienie o ID #" + myOrder.Id + "\n" +
                                 "Złożono: " + myOrder.OrderTime + "\n" +
                                 "Zakończono: " + myOrder.ReadyTime + "\n" +
                                 "Na kwotę: " + myOrder.TotalPrice + "\n" +
                                 "Notatka to: " + myOrder.Note + "\n\n" +
                                 "Zamówiono: \n");

                foreach (OrderDetails var in myOrder.Items)
                {
                    msgDetail.Append($@"- {var.Quantity} x {var.ItemName.TrimEnd()} za {var.Price}PLN sztuka {Environment.NewLine}");
                }

                MessageBox.Show(msgDetail.ToString(), "Szczegóły zamówienia", MessageBoxButton.OK,
                    MessageBoxImage.Information);


            }
        }
    }
}
