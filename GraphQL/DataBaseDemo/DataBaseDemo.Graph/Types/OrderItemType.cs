using DataBaseDemo.Model;
using DataBaseDemo.Services;
using GraphQL.Types;
using System.Linq;
namespace DataBaseDemo.Graph.Types
{
    public class OrderItemType : ObjectGraphType<OrderItem>
    {
        public OrderItemType(InventoryContext context)
        {
            Field(i => i.Id);
            Field<ItemType, Item>().Name("Item").Resolve(ctx =>
            {
                return context.Items.Single(x=>x.Id == ctx.Source.Id);
            });
            Field(i => i.Quantity);
            Field(i => i.OrderId);
            Field<OrderType, Order>().Name("Order").Resolve(ctx =>
            {
                return context.Orders.Single(x => x.Id == ctx.Source.OrderId);
            });
        }
    }
}
