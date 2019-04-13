using System;
using System.Collections.Generic;

namespace DataBaseDemo.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
