using System;
using OrderManagementAppService;
using OrderManagementModels;

namespace OrderManagement
{
    class Program
    {
        static OrderService service = new OrderService();

        static void Main(string[] args)
        {
            string choice;
            char loop;
            do
            {   
                Console.Clear();
                ShowMenu();
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateOrder();
                        break;

                    case "2":
                        CancelOrder();
                        break;

                    case "3":
                        ViewOrders();
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.Write("do you want another Transaction press (Y - Yes | N - No: ");
                loop = Convert.ToChar(Console.ReadLine());
            } while (loop == 'y' || loop == 'Y');
        }

        static void ShowMenu()
        {
            Console.WriteLine("\n===== ORDER MANAGEMENT =====");
            Console.WriteLine("1. Create Order");
            Console.WriteLine("2. Cancel Last Order");
            Console.WriteLine("3. View Orders");
            Console.Write("Choice: ");
        }

        static void CreateOrder()
        {
            Console.WriteLine("\nBalance: " + service.Balance);

            Console.WriteLine("1 Fish - 200");
            Console.WriteLine("2 Pork - 300");
            Console.WriteLine("3 Chicken - 100");

            Console.Write("Select: ");
            string select = Console.ReadLine();

            Console.Write("Quantity: ");
            int qty = Convert.ToInt32(Console.ReadLine());

            Console.Write("Delivery Date (yyyy-mm-dd): ");
            DateTime deliveryDate = Convert.ToDateTime(Console.ReadLine());

            string item = "";
            double price = 0;

            if (select == "1")
            {
                item = "Fish";
                price = 200;
            }
            else if (select == "2")
            {
                item = "Pork";
                price = 300;
            }
            else if (select == "3")
            {
                item = "Chicken";
                price = 100;
            }
            else
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            bool success = service.CreateOrder(item, qty, price, deliveryDate);

            if (success)
                Console.WriteLine("Order Added!");
            else
                Console.WriteLine("Insufficient Balance");
        }

        static void CancelOrder()
        {
            var cancelled = service.CancelLastOrder();

            if (cancelled != null)
                Console.WriteLine("Cancelled: " + cancelled.ItemName);
            else
                Console.WriteLine("No orders found.");
        }

        static void ViewOrders()
        {
            var orders = service.GetOrders();

            Console.WriteLine("\n===== ORDER LIST =====");

            foreach (var o in orders)
            {
                Console.WriteLine($"{o.ItemName} x{o.Quantity} - {o.TotalPrice} | Delivery: {o.DeliveryDate.ToShortDateString()}");
            }

            Console.WriteLine("Remaining Balance: " + service.Balance);
        }
    }
}