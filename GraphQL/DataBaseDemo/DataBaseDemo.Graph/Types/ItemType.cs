using DataBaseDemo.Model;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseDemo.Graph.Types
{
    public class ItemType : ObjectGraphType<Item>
    {
        public ItemType()
        {
            Field(i => i.Id);
            Field(i => i.Title);
            Field(i => i.SellingPrice);
            Field<ListGraphType<OrderItemType>, IEnumerable<OrderItem>>().
                Name("OrderItems").Resolve(ctx => ctx.Source.OrderItems);
        }
    }
}
