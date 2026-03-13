using System;
using OrderManagementAppService;


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

                Console.Write("\ndo you want another Transaction press (Y - Yes | N - No: ");
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
            Console.WriteLine("\n============================");
            Console.WriteLine("Balance: " + service.Balance);
            Console.WriteLine("============================");
            Console.WriteLine("Select Item:");
            Console.WriteLine("1 Fish - 200");
            Console.WriteLine("2 Pork - 300");
            Console.WriteLine("3 Chicken - 100");
            Console.WriteLine("4 Beef - 250");
            Console.WriteLine("5 Lamb - 450");
            Console.WriteLine("6 Goat - 350");
            Console.WriteLine("7 Venison - 325");
            Console.WriteLine("8 Turkey - 500");
            Console.WriteLine("9 Duck - 400");
            Console.WriteLine("10 Salmon - 560");
            Console.WriteLine("11 Crab - 250");
            Console.WriteLine("12 Shrimp - 350");
            

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
            else if (select == "4")
            {
                item = "Beef";
                price = 250;
            }
            else if (select == "5")
            {
                item = "Lamb";
                price = 450;
            }
            else if (select == "6")
            {
                item = "Goat";
                price = 350;
            }
            else if (select == "7")
            {
                item = "Venison";
                price = 325;
            }
            else if (select == "8")
            {
                item = "Turkey";
                price = 500;
            }
            else if (select == "9")
            {
                item = "Duck";
                price = 400;
            }
            else if (select == "10")
            {
                item = "Salmon";
                price = 560;
            }
            else if (select == "11")
            {
                item = "Crab";
                price = 250;
            }
            else if (select == "12")
            {
                item = "Shrimp";
                price = 350;
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

            Console.WriteLine("\n===== ORDER LIST =====\n");

            foreach (var o in orders)
            {
                Console.WriteLine($"{o.ItemName} x{o.Quantity} - {o.TotalPrice} | Delivery: {o.DeliveryDate.ToShortDateString()}");
            }

            Console.WriteLine("Remaining Balance: " + service.Balance);
        }
    }
}