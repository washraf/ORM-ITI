using GraphQL.Types;
using SimpleDemo2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleDemo2.Query
{
    public class InventoryMutation: ObjectGraphType
    {
        public InventoryMutation(DataSource dataStore)
        {
            Field<ItemType>(
                "createItem",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ItemInputType>> 
                        { Name = "item" }
                ),
                resolve: context =>
                {
                    var item = context.GetArgument<Item>("item");
                    return dataStore.AddItem(item);
                });

            Field<ItemType>(
                "updateItem",
                arguments: new QueryArguments
                (new QueryArgument<NonNullGraphType<ItemInputType>>
                { Name = "item"}),
                resolve: context =>
                {
                    var item = context.GetArgument<Item>("item");
                    return dataStore.UpdateItem(item);
                });

            Field<StringGraphType>(
                "deleteItem",
                arguments: new QueryArguments
                (new QueryArgument<NonNullGraphType<StringGraphType>>
                { Name = "barcode" }),
                resolve: context =>
                {
                    var barCode = context.GetArgument<string>("barcode");
                    return dataStore.DeleteItem(barCode);
                });
        }
    }
}
