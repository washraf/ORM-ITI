using DataBaseDemo.Model;
using DataBaseDemo.Services;
using GraphQL.Types;
using System.Collections.Generic;
using System.Linq;
namespace DataBaseDemo.Graph.Types
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType(InventoryContext context)
        {
            Field(o => o.Id);
            Field(o => o.Tag);
            Field(o => o.CreatedAt);
            Field<CustomerType, Customer>()
                .Name("Customer")
                .Resolve(ctx => {
                    return context.Customers
                    .Single(x => x.Id == ctx.Source.CustomerId);
                });

            Field<ListGraphType<OrderItemType>,
                IEnumerable<OrderItem>>()
                .Name("OrderItems").Resolve(ctx => {
                    return context.OrderItems.Where(x => x.OrderId == ctx.Source.Id);
                    });


        }

    }
}
