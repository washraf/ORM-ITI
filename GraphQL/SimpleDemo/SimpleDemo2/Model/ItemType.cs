using GraphQL.Types;
using System.Collections.Generic;
namespace SimpleDemo2.Model
{
    public class ItemType : ObjectGraphType<Item>
    {
        public ItemType()
        {
            Field(i => i.Barcode);
            Field(i => i.Title);
            Field(i => i.SellingPrice);
            Field<ListGraphType<OrderItemType>, IEnumerable<OrderItem>>().
                Name("OrderItems").Resolve(ctx => ctx.Source.OrderItems);
        }
    }
}
