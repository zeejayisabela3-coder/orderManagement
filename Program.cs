namespace orderManagement
{
    internal class Program
    {
       

        static void Main(string[] args)
        {
            double money = 10000.00;
            char again;
            do { 
                string username = "lodi";
                Console.WriteLine("");
                Console.WriteLine("ORDER MANAGEMENT");
                Console.WriteLine("1. Create Order");
                Console.WriteLine("2. Cancel Order");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Current Balance: " + money);
                        Console.Write("List Order: \n1. Fish \n2. pork \n3. chicken\n");

                        Console.Write("Create Order: ");
                        string order = Convert.ToString(Console.ReadLine());

                        if (order == "1")
                        {
                            Console.WriteLine("Fish price: 200");
                            Console.WriteLine("Remaining Balance: " + (money - 200));
                            Console.WriteLine("Thank you for your order!");
                        }
                        else if (order == "2")
                        {
                            Console.WriteLine("Pork price: 300");
                            Console.WriteLine("Remaining Balance: " + (money - 300));
                            Console.WriteLine("Thank you for your order!");
                        }
                        else if (order == "3")
                        {
                            Console.WriteLine("Chicken price: 100");
                            Console.WriteLine("Remaining Balance: " + (money - 100));
                            Console.WriteLine("Thank you for your order!");
                        }

                        break;
                    case "2":
                        Console.WriteLine("deletion of orders");
                        break;
                    case "3":
                        Console.WriteLine("Exitting, Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.Write("\nDo you want to pay another bill? (Y/N): ");
                again = Convert.ToChar(Console.ReadLine());

            } while (again == 'Y' || again == 'y');

            Console.WriteLine("Thank you for using the app!");
        }

    }
    }

