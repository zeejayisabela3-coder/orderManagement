using OrderManagementModels;
using System.Collections.Generic;

namespace OrderManagementDataService
{
    public class OrderRepository
    {
        private JsonOrderRepository jsonRepo = new JsonOrderRepository();
        private OrderDBRepository dbRepo = new OrderDBRepository();

        public void AddOrder(Order order)
        {
            Console.WriteLine("Adding order...");
            jsonRepo.AddOrder(order);
            dbRepo.AddOrder(order);
        }

        public void RemoveLastOrder()
        {
            jsonRepo.RemoveLastOrder();
            dbRepo.RemoveLastOrder();
        }

        public List<Order> GetOrders()
        {
            return dbRepo.GetOrders();
        }

        public Order GetLastOrder()
        {
            return dbRepo.GetLastOrder();
        }
    }
}