using DataBaseDemo.Model;
using DataBaseDemo.Services;
using GraphQL.Types;
using System.Collections.Generic;
using System.Linq;

namespace DataBaseDemo.Graph.Types
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType(InventoryContext context)
        {
            Field(c => c.Id);
            Field(c => c.Name);
            Field(c => c.Address);
            Field<ListGraphType<OrderType>, IEnumerable<Order>>()
                .Name("Orders")
                .Resolve(ctx => {
                    return context.Orders
                    .Where(x=>x.CustomerId == ctx.Source.Id)
                    .ToList();
                });
            Field<StringGraphType>()
                .Name("History")
                .Resolve(ctx => {
                    return "The history of customer "+ctx.Source.Id;

                });
        }
    }
}
