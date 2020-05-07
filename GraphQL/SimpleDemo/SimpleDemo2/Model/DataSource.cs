using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace SimpleDemo2.Model
{
    public class DataSource
    {
        public IList<Item> Items
        {
            get;
            set;
        }

        public IList<Customer> Customers
        {
            get;set;
        }
        public IList<Order> Orders
        {
            get;set;
        }
        public IList<OrderItem> OrderItems { get; set; }

        public DataSource()
        {
            Items = new List<Item>(){
                new Item { Barcode= "123", Title="Headphone", SellingPrice=50,
                OrderItems = new List<OrderItem>()
                    {
                        new OrderItem()
                            {
                                Id = 1,
                                ItemBarCode = "123",
                                OrderId = 1,
                                Quantity = 10,
                            }
                    }},
                new Item { Barcode= "456", Title="Keyboard", SellingPrice= 40},
                new Item { Barcode= "789", Title="Monitor", SellingPrice= 100}
            };
            Customers = new List<Customer>()
            {
                new Customer()
                {
                    CustomerId = 1,
                    BillingAddress = "Home",
                    Name = "Customer1"
                }
            };
            Orders = new List<Order>()
            {
                new Order()
                {
                    CreatedAt = DateTime.Now,
                    CustomerId = 1,
                    OrderId = 1,
                    Tag = "No Tag",
                    OrderItems = new List<OrderItem>()
                    {
                        new OrderItem()
                            {
                                Id = 1,
                                ItemBarCode = "123",
                                OrderId = 1,
                                Quantity = 10,
                            }
                    }
                }
            };
            OrderItems = new List<OrderItem>()
            {
                new OrderItem()
                {
                    Id = 1,
                    ItemBarCode = "123",
                    OrderId = 1,
                    Quantity = 10,
                }
            };
        }

        internal Order GetOrderById(int orderId)
        {
            return Orders.Single(x => x.OrderId == orderId);
        }

        public List<Order> GetOrdersByCustomerId(int customerId)
        {
            return Orders.Where(x => x.CustomerId == customerId)
                .ToList();
        }

        public Customer GetCustomerById(int customerId)
        {
            return Customers.Single(x => x.CustomerId == customerId);
        }

        public Item GetItemByBarcode(string barcode)
        {
            return Items.First(i => i.Barcode.Equals(barcode));
        }

        public Item AddItem(Item item)
        {
            Items.Add(item);
            return item;
        }

        public List<Item> GetItems()
        {
            return Items.ToList();
        }

        public Item UpdateItem(Item item)
        {

            return item;
        }

        internal string DeleteItem(string barCode)
        {
            var i = Items.Single(x => x.Barcode == barCode);
            Items.Remove(i);
            return "Done";
        }
    }
}
