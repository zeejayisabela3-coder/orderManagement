using OrderManagementDataService;
using OrderManagementModels;
using System.Collections.Generic;

namespace OrderManagementAppService
{
    public class OrderService
    {
        private OrderRepository repo = new OrderRepository();

        private const double INITIAL_BALANCE = 10000;

        public double GetBalance()
        {
            double totalSpent = 0;

            foreach (var o in repo.GetOrders())
            {
                totalSpent += o.TotalPrice;
            }

            return INITIAL_BALANCE - totalSpent;
        }

        public bool CreateOrder(string item, int qty, double price, DateTime deliveryDate)
        {
            double total = price * qty;

            if (GetBalance() >= total)
            {
               

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
            var last = repo.GetLastOrder();

            if (last == null)
                return false;

            double oldTotal = last.TotalPrice;
            double unitPrice = oldTotal / last.Quantity;
            double newTotal = unitPrice * newQty;

            double difference = newTotal - oldTotal;

            if (difference > 0 && GetBalance() < difference)
                return false;

            last.Quantity = newQty;
            last.TotalPrice = newTotal;
            last.DeliveryDate = newDate;

            repo.UpdateLastOrder(last);

            return true;
        }
    }
}