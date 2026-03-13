using System;
using OrderManagementAppService;
using OrderManagementModels;

namespace OrderManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService service = new OrderService();
            string choice;

            do
            {
                Console.WriteLine("\n===== ORDER MANAGEMENT =====");
                Console.WriteLine("1. Create Order");
                Console.WriteLine("2. Cancel Last Order");
                Console.WriteLine("3. View Orders");
                Console.WriteLine("4. Exit");

                Console.Write("Choice: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":

                        Console.WriteLine("Balance: " + service.Balance);

                        Console.WriteLine("1 Fish - 200");
                        Console.WriteLine("2 Pork - 300");
                        Console.WriteLine("3 Chicken - 100");

                        Console.Write("Select: ");
                        string select = Console.ReadLine();

                        Console.Write("Quantity: ");
                        int qty = Convert.ToInt32(Console.ReadLine());

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

                        bool success = service.CreateOrder(item, qty, price);

                        if (success)
                            Console.WriteLine("Order Added!");
                        else
                            Console.WriteLine("Insufficient Balance");

                        break;

                    case "2":

                        var cancelled = service.CancelLastOrder();

                        if (cancelled != null)
                            Console.WriteLine("Cancelled: " + cancelled.ItemName);
                        else
                            Console.WriteLine("No orders");

                        break;

                    case "3":

                        var orders = service.GetOrders();

                        foreach (var o in orders)
                        {
                            Console.WriteLine($"{o.ItemName} x{o.Quantity} - {o.TotalPrice}");
                        }

                        Console.WriteLine("Balance: " + service.Balance);

                        break;

                }

            } while (choice != "4");
        }
    }
}