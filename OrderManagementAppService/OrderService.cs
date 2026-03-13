using OrderManagementDataService;
using OrderManagementModels;
using System.Collections.Generic;

namespace OrderManagementAppService
{
    public class OrderService
    {
        private OrderRepository repo = new OrderRepository();

        public double Balance { get; private set; } = 10000;

        public bool CreateOrder(string item, int qty, double price)
        {
            double total = price * qty;

            if (Balance >= total)
            {
                Balance -= total;

                Order order = new Order
                {
                    ItemName = item,
                    Quantity = qty,
                    TotalPrice = total
                };

                repo.AddOrder(order);

                return true;
            }

            return false;
        }

        public Order CancelLastOrder()
        {
            Order last = repo.GetLastOrder();

            if (last != null)
            {
                Balance += last.TotalPrice;
                repo.RemoveLastOrder();
            }

            return last;
        }

        public List<Order> GetOrders()
        {
            return repo.GetOrders();
        }
    }
}