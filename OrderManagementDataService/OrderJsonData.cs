using Newtonsoft.Json;
using OrderManagementModels;
using System.Collections.Generic;
using System.IO;


namespace OrderManagementDataService
{
    public class JsonOrderRepository
    {
        private string filePath = @"C:\Users\Karl\Documents\GitHub\orderManagement\OrderManagementDataService\orders.json";

        public List<Order> GetOrders()
        {
            if (!File.Exists(filePath))
                return new List<Order>();

            string json = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<List<Order>>(json)
                   ?? new List<Order>();
        }

        public void SaveOrders(List<Order> orders)
        {
            string json = JsonConvert.SerializeObject(orders, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public void AddOrder(Order order)
        {
            var orders = GetOrders();
            orders.Add(order);
            SaveOrders(orders);
        }

        public void RemoveLastOrder()
        {
            var orders = GetOrders();

            if (orders.Count > 0)
            {
                orders.RemoveAt(orders.Count - 1);
                SaveOrders(orders);
            }
        }

        public Order GetLastOrder()
        {
            var orders = GetOrders();

            if (orders.Count == 0)
                return null;

            return orders[orders.Count - 1];
        }
    }
}