using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows;

namespace KelnerPlus
{
    public class Connections
    {
        public static SqlConnection Connection;
        public static string ConnectionString;

        /// <summary>
        /// Sprawdza czy jest połączenie z naszą bazą
        /// </summary>
        /// <returns>zwraca true, jeżeli połączenie zostało utworzone</returns>
        public static bool IsServerConnected()
        {
            ConnectionString = GetConnectionString();

            using (Connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    Connection?.Close();
                    Connection.Open();
                    Connection?.Close();
                    return true;
                }
                catch (SqlException ex)
                {
                    StringBuilder errorMessages = new StringBuilder();
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                                             "Message: " + ex.Errors[i].Message + "\n" +
                                             "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                                             "Source: " + ex.Errors[i].Source + "\n" +
                                             "Procedure: " + ex.Errors[i].Procedure + "\n");
                    }

                    MessageBox.Show(errorMessages.ToString());
                    return false;
                }
            }
        }

        /// <summary>
        /// Pobieranie elementów z tabeli Orders
        /// </summary>
        /// <returns>zwraca listę Zamówień</returns>
        public static List<Order> GeOrders()
        {
            List<Order> orders = new List<Order>();

            ConnectionString = GetConnectionString();
            using (Connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    Connection?.Close();
                    Connection.Open();
                    SqlDataReader rdr;
                    string query =
                        "SELECT * FROM [dbo].[Orders] ORDER BY order_time DESC;";
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    using (rdr = command.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Order var = new Order
                            {
                                Id = rdr.GetInt32(0),
                                Status = rdr.GetInt32(1),
                                OrderTime = rdr.GetValue(2).ToString(),
                                ReadyTime = rdr.GetValue(3).ToString(),
                                TotalPrice = rdr.GetDouble(4),
                                Note = rdr.GetValue(5).ToString()
                            };
                            orders.Add(var);
                        }

                        rdr.Close();
                        command.Dispose();
                        Connection?.Close();
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            return orders;


        }

        /// <summary>
        /// Wykonanie polecenia na bazie
        /// </summary>
        /// <param name="cmd">SQL query</param>
        /// <returns> zwraca pierwszy element odpowiedzi z bazy </returns>
        public static string ExecuteSqlCommand(string cmd)
        {
            string answer ="";
            using (Connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    Connection?.Close();
                    Connection.Open();
                    using (SqlCommand command = new SqlCommand(cmd, Connection))
                    {
                        SqlDataReader rdr;
                        using (rdr = command.ExecuteReader())
                        {
                            while (rdr.Read())
                            {

                                answer= rdr.GetValue(0).ToString();
                            }
                            rdr.Close();
                            command.Dispose();
                            Connection?.Close();
                        }
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            return answer; 
        }

        /// <summary>
        /// Pobieranie dostępnego menu
        /// </summary>
        /// <returns> zwraca listę przedmiotów w menu</returns>
        public static List<MenuItem> GetMenuItems()
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            ConnectionString = GetConnectionString();
            using (Connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    Connection?.Close();
                    Connection.Open();
                    SqlDataReader rdr;
                    string query =
                        "SELECT [id],[item_name],[description],[category_id],[ingredients],[price],[active],[vege],[lactose]FROM [MenuItems]";
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    using (rdr = command.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            MenuItem var = new MenuItem
                            {
                                Id = rdr.GetInt32(0),
                                ItemName = rdr.GetValue(1).ToString(),
                                Description = rdr.GetValue(2).ToString(),
                                CategoryId = rdr.GetInt32(3),
                                Ingredients = rdr.GetValue(4).ToString(),
                                Price = rdr.GetDouble(5),
                                IsActive = rdr.GetBoolean(6),
                                IsVege = rdr.GetBoolean(7),
                                IsLactose = rdr.GetBoolean(8)
                            };
                            
                            menuItems.Add(var);

                        }

                        rdr.Close();
                        command.Dispose();
                        Connection?.Close();
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            return menuItems;

        }

        /// <summary>
        /// Pobieranie ustawień bazy
        /// </summary>
        /// <returns>zwraca ConnectionString</returns>
        public static string GetConnectionString()
        {
            string dbServer = Properties.Settings.Default.ServerName;
            string dbName = Properties.Settings.Default.DBName;
            string dbUser = Properties.Settings.Default.DBUserName;
            string dbPass = Properties.Settings.Default.DBPassword; 


            ConnectionString = $"server={dbServer};database={dbName};uid={dbUser};password={dbPass};";

            return ConnectionString;
        }

        /// <summary>
        /// Pobieranie szczegółów zamówienia
        /// </summary>
        /// <param name="orderId"> id zamówienia, którego szczegóły zamóienia szukamy</param>
        /// <returns> zwraca listę szczegółów zamówienia</returns>
        public static List<OrderDetails> GetDetails(int orderId)
        {
            List<OrderDetails> ordersDetails = new List<OrderDetails>();

            ConnectionString = GetConnectionString();
            using (Connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    Connection?.Close();
                    Connection.Open();
                    SqlDataReader rdr;
                    string query =
                        $@"SELECT DetailsOrder.id, item_name, menu_item_id, price, quantity FROM dbo.DetailsOrder INNER JOIN dbo.MenuItems ON DetailsOrder.menu_item_id=MenuItems.id WHERE order_id = {orderId};";
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    using (rdr = command.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            OrderDetails var = new OrderDetails
                            {
                                Id = rdr.GetInt32(0),
                                ItemName = rdr.GetValue(1).ToString(),
                                MenuItemId = rdr.GetInt32(2),
                                Price = rdr.GetDouble(3),
                                OrderId = orderId,
                                Quantity = rdr.GetInt32(4)
                            };

                            ordersDetails.Add(var);
                        }

                        rdr.Close();
                        command.Dispose();
                        Connection?.Close();
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            return ordersDetails;
        }

        
        /// <summary>
        /// Zmienia status zamówienia na zakończon

        /// </summary

        /// <param name="myOrderId">id zamówienia, które trzeba zakończyć</param

        /// <param name="readyTime">czas zakończenia</param

        public static void ChangeStatus(int myOrderId, string readyTime)
        {
            Connections.ExecuteSqlCommand($@"UPDATE Orders SET order_status=2, ready_time='{readyTime}' WHERE id= {myOrderId};");
        }
    }
}
