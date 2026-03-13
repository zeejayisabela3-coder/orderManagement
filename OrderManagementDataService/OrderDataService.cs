using OrderManagementModels;
using System.Collections.Generic;

namespace OrderManagementDataService
{
    public class OrderRepository
    {
        private List<Order> orders = new List<Order>();

        public void AddOrder(Order order)
        {
            orders.Add(order);
        }

        public void RemoveLastOrder()
        {
            if (orders.Count > 0)
                orders.RemoveAt(orders.Count - 1);
        }

        public List<Order> GetOrders()
        {
            return orders;
        }

        public Order GetLastOrder()
        {
            if (orders.Count == 0)
                return null;

            return orders[orders.Count - 1];
        }
    }
}