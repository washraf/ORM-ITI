using DataBaseDemo.Graph.Types;
using DataBaseDemo.Model;
using DataBaseDemo.Services;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataBaseDemo.Graph.Query
{

    public class InventoryQuery : ObjectGraphType
    {
        public InventoryQuery(InventoryContext context)
        {

            Field<ListGraphType<ItemType>>(
                "items",
                resolve: ctx =>
                {
                    return context.Items.ToList();
                }
            );
            Field<ListGraphType<OrderType>, IEnumerable<Order>>()
                .Name("Orders")
                .Resolve(ctx =>
                {
                    return context.Orders.ToList();
                });

            Field<ListGraphType<CustomerType>, IEnumerable<Customer>>()
                .Name("Customers")
                .Resolve(ctx =>
                {
                    return context.Customers.ToList();
                });

            Field<ListGraphType<OrderItemType>, IEnumerable<OrderItem>>()
                .Name("OrderItems")
                .Resolve(ctx => context.OrderItems.ToList());
        }

    }
}
