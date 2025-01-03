namespace DAL.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } // Navigation Property
        public int ProductId { get; set; }
        public Product Product { get; set; } // Navigation Property
        public int Quantity { get; set; }
    }
}

