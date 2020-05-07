using GraphQL.Types;

namespace SimpleDemo2.Model
{
    public class OrderItemType : ObjectGraphType<OrderItem>
    {
        public OrderItemType(DataSource dataSource)
        {
            Field(i => i.ItemBarCode);
            Field<ItemType, Item>().Name("Item").Resolve(ctx =>
            {
                return dataSource.GetItemByBarcode(ctx.Source.ItemBarCode);
            });
            Field(i => i.Quantity);
            Field(i => i.OrderId);
            Field<OrderType, Order>().Name("Order").Resolve(ctx =>
            {
                return dataSource.GetOrderById(ctx.Source.OrderId);
            });
        }
    }
}
