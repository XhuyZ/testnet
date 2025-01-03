using System.Collections.Generic;
namespace DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } // Navigation Property
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

