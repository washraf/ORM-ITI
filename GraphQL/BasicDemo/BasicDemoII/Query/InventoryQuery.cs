using BasicDemoII.Model;
using GraphQL.Types;
using System.Collections.Generic;
using System.Linq;
namespace BasicDemoII.Query
{
    public class InventoryQuery : ObjectGraphType
    {
        public InventoryQuery(DataSource dataSource)
        {
            
            Field<ItemType>(
                "item",
                arguments: new QueryArguments
                (new QueryArgument<NonNullGraphType<StringGraphType>>
                { Name = "barcode" }),
                resolve: context =>
                {
                    var barcode = context.GetArgument<string>("barcode");
                    return dataSource.GetItemByBarcode(barcode);
                }
            );
            Field<ListGraphType<ItemType>>(
                "items",
                resolve: context =>
                {
                    return dataSource.GetItems();
                }
            );
            Field<ListGraphType<OrderType>, IEnumerable<Order>>()
                .Name("Orders")
                .Resolve(ctx =>
                {
                    return dataSource.Orders.ToList();
                });

            Field<ListGraphType<CustomerType>, IEnumerable<Customer>>()
                .Name("Customers")
                .Resolve(ctx =>
                {
                    return dataSource.Customers.ToList();
                });

            Field<ListGraphType<OrderItemType>, IEnumerable<OrderItem>>()
                .Name("OrderItems")
                .Resolve(ctx =>dataSource.OrderItems.ToList());
        }

    }
}
