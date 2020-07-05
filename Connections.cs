using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace KelnerPlus
{
    public class Connections
    {
        public static SqlConnection Connection;
        public static string ConnectionString;

        /// <summary>
        /// Test that the server is connected
        /// </summary>
        /// <returns>true if the connection is opened</returns>
        public static bool IsServerConnected()
        {
            string dbServer = Properties.Settings.Default.ServerName;
            string dbName = Properties.Settings.Default.DBName;
            string dbUser = Properties.Settings.Default.DBUserName;
            string dbPass = Properties.Settings.Default.DBPassword;


            Thread.Sleep(2000);
            ConnectionString = $"server={dbServer};database={dbName};uid={dbUser};password={dbPass};";
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

        public static SqlDataReader ExecuteSqlCommand(string cmd)
        {
            SqlDataReader rdr = null;
            using (Connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    Connection?.Close();
                    Connection.Open();
                    using (SqlCommand command = new SqlCommand(cmd, Connection))
                    using (rdr = command.ExecuteReader())
                    {
                        while (rdr.Read())
                        {

                            MessageBox.Show(rdr.GetValue(1).ToString());
                        }
                        rdr.Close();
                        command.Dispose();
                        Connection?.Close();
                    }
                }
                catch
                {

                }
            }
            return rdr;
        }

        public static List<MenuItem> GetMenuItems()
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            ConnectionString = $"server=Desktop;database=kitchen;uid=sa;password=test;";
            using (Connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    Connection?.Close();
                    Connection.Open();
                    SqlDataReader rdr;
                    string query =
                        "SELECT [id],[item_name],[description],[category_id],[ingredients],[price],[active],[vege],[lactose]FROM [kitchen].[dbo].[menu_Items]";
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    using (rdr = command.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            /* MenuItem var = new MenuItem(rdr.GetInt32(0),
                             rdr.GetValue(1).ToString(),
                             rdr.GetValue(2).ToString(),
                             rdr.GetInt32(3),
                             rdr.GetValue(4).ToString(),
                             rdr.GetDouble(5),
                             rdr.GetBoolean(6),
                             rdr.GetBoolean(7),
                             rdr.GetBoolean(8));
                            */
                            MenuItem var = new MenuItem();
                            var.id = rdr.GetInt32(0);
                            var.itemName = rdr.GetValue(1).ToString();
                            
                            var.description = rdr.GetValue(2).ToString();
                            var.categoryId = rdr.GetInt32(3);
                            var.ingredients = rdr.GetValue(4).ToString();
                            var.price = rdr.GetDouble(5);
                            var.isActive = rdr.GetBoolean(6);
                            var.isVege = rdr.GetBoolean(7);
                            var.isLactose = rdr.GetBoolean(8);

                            menuItems.Add(var);

                        }

                        rdr.Close();
                        command.Dispose();
                        Connection?.Close();
                    }
                }
                catch
                {

                }
            }

            return menuItems;

        }
    }
}
