namespace orderManagement
{
    internal class Program
    {
       

        static void Main(string[] args)
        {
           
            while (true)
            {
                Console.WriteLine("ORDER MANAGEMENT");
                Console.WriteLine("1. View Order");
                Console.WriteLine("2. Update Order");
                Console.WriteLine("3. Delete Order");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Viewing of Order");
                        break;
                    case "2":
                        Console.WriteLine("Updating of orders");
                        break;
                    case "3":
                        Console.WriteLine("deletion of orders");
                        break;
                    case "4":
                        Console.WriteLine("Exitting, Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            
        }
    }
}
