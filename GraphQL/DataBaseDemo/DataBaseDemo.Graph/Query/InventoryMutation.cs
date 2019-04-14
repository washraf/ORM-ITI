using DataBaseDemo.Graph.InputTypes;
using DataBaseDemo.Graph.Types;
using DataBaseDemo.Model;
using DataBaseDemo.Services;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseDemo.Graph.Query
{
    public class InventoryMutation: ObjectGraphType
    {
        public InventoryMutation(InventoryContext context)
        {
            Field<IntGraphType>(
                "createItem",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ItemInputType>>
                    { Name = "item" }
                ),
                resolve: ctx =>
                {
                    var item = ctx.GetValidatedArgument<Item>("item");
                    context.Items.Add(item);
                    context.SaveChanges();
                    return item.Id;
                });

            Field<IntGraphType>(
                "createCustomer",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CustomerInput>>
                    {
                        Name = "customer"
                    }),
                resolve: ctx =>
                {
                    var customer = ctx.GetValidatedArgument<Customer>("customer");
                    context.Customers.Add(customer);
                    context.SaveChanges();
                    return customer.Id;
                }
                );
        }
    }
}
