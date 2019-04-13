using System.Collections.Generic;

namespace DataBaseDemo.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal SellingPrice { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
