using OrderManagementDataService;
using OrderManagementModels;
using System;
using System.Collections.Generic;

namespace OrderManagementAppService
{
    public class OrderService
    {
        private OrderRepository repo = new OrderRepository();

        public double Balance { get; private set; } = 10000;

        public double GetBalance()
        {
            return Balance;
        }

        public bool CreateOrder(string item, int qty, double price, DateTime deliveryDate)
        {
            double total = price * qty;

            if (Balance >= total)
            {
                Balance -= total;

                Order order = new Order
                {
                    ItemName = item,
                    Quantity = qty,
                    TotalPrice = total,
                    DeliveryDate = deliveryDate
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

        public Order GetLastOrder()
        {
            return repo.GetLastOrder();
        }

        public bool UpdateLastOrder(int newQty, DateTime newDate)
        {
            Order last = repo.GetLastOrder();

            if (last == null)
                return false;

            double unitPrice = last.TotalPrice / last.Quantity;

            double oldTotal = last.TotalPrice;
            double newTotal = unitPrice * newQty;

            double difference = newTotal - oldTotal;

            if (difference > Balance)
                return false;

            Balance -= difference;

            last.Quantity = newQty;
            last.TotalPrice = newTotal;
            last.DeliveryDate = newDate;

            repo.UpdateLastOrder(last);

            return true;
        }
    }
}