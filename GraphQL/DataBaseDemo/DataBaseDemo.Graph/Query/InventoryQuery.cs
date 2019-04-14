using DataBaseDemo.Graph.Types;
using DataBaseDemo.Model;
using DataBaseDemo.Services;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataBaseDemo.Graph.Filter;

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
            Field<ListGraphType<OrderType>>()
                .Name("Orders")
                .Resolve(ctx =>
                {
                    return context.Orders.ToList();
                });

            Field<ListGraphType<CustomerType>>(
                "Customers",
                arguments: new QueryArguments
                (new QueryArgument<NonNullGraphType<CustomerQueryFilter>>
                { Name = "filter" }),
                resolve:(ctx =>
                {
                    var filter = ctx.
                    GetArgument<CustomerQuery>("filter");
                    if(filter==null)
                        return context.Customers.ToList();
                    else
                    {
                        //Do Manual Filtring and Sorting
                        ///
                        /// todo: Support Dynamic Linq
                        ///
                        var customers = context.Customers.AsQueryable();
                        if(!string.IsNullOrEmpty(filter.CustomerName))
                        {
                            customers = customers
                            .Where(x => x.Name.Contains(filter.CustomerName));
                        }
                        customers =  customers
                        .Skip(filter.PageNumber * filter.PageSize)
                        .Take(filter.PageSize);
                        return customers.ToList();
                    }
                }));
                

            Field<ListGraphType<OrderItemType>, IEnumerable<OrderItem>>()
                .Name("OrderItems")
                .Resolve(ctx => context.OrderItems.ToList());

            Field<ItemType>(
                "item",
                arguments: new QueryArguments
                (new QueryArgument<NonNullGraphType<IntGraphType>>
                { Name = "id" }),
                resolve: ctx => {
                    var id = ctx.GetArgument<int>("id");

                    return context.Items.Single(x => x.Id == id);
                });
        }

    }
}
