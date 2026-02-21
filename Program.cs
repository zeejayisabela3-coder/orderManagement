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
                        Console.WriteLine("username: zj" +
                            "item: pencil" +
                            "price: 10kyaw" +
                            "address: blk 12 lot 16 loma,binan laguna");
                        break;
                    case "2":
                        Console.WriteLine("Updating of orders");
                        Console.WriteLine("enter username: ");
                        String username = Console.ReadLine();

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
