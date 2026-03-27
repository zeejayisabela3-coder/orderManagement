using Microsoft.Data.SqlClient;
using OrderManagementModels;
using System;
using System.Collections.Generic;

namespace OrderManagementDataService
{
    public class OrderDBRepository
    {
        private string connectionString =
"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OrderManagementDB;Integrated Security=True;TrustServerCertificate=True;";

        private SqlConnection sqlConnection;

        public OrderDBRepository()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public void AddOrder(Order order)
        {
            string query = @"INSERT INTO Orders (item_name, quantity, total_price, delivery_date)
                             VALUES (@item, @qty, @price, @date)";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);

            cmd.Parameters.AddWithValue("@item", order.ItemName);
            cmd.Parameters.AddWithValue("@qty", order.Quantity);
            cmd.Parameters.AddWithValue("@price", order.TotalPrice);
            cmd.Parameters.AddWithValue("@date", order.DeliveryDate);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<Order> GetOrders()
        {
            var list = new List<Order>();

            string query = "SELECT * FROM Orders";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Order
                {
                    ItemName = reader["item_name"].ToString(),
                    Quantity = Convert.ToInt32(reader["quantity"]),
                    TotalPrice = Convert.ToDouble(reader["total_price"]),
                    DeliveryDate = Convert.ToDateTime(reader["delivery_date"])
                });
            }

            sqlConnection.Close();

            return list;
        }

        public void RemoveLastOrder()
        {
            string query = "DELETE FROM Orders WHERE Id = (SELECT MAX(Id) FROM Orders)";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public Order GetLastOrder()
        {
            string query = "SELECT TOP 1 * FROM Orders ORDER BY Id DESC";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            Order order = null;

            if (reader.Read())
            {
                order = new Order
                {
                    ItemName = reader["item_name"].ToString(),
                    Quantity = Convert.ToInt32(reader["quantity"]),
                    TotalPrice = Convert.ToDouble(reader["total_price"]),
                    DeliveryDate = Convert.ToDateTime(reader["delivery_date"])
                };
            }

            sqlConnection.Close();

            return order;
        }
    }
}