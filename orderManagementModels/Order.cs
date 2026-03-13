namespace OrderManagementModels
{
    public class Order
    {
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}