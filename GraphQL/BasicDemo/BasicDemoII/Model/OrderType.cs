using GraphQL.Types;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace BasicDemoII.Model
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType(DataSource dataSource)
        {
            Field(o => o.OrderId);
            Field(o => o.Tag);
            Field(o => o.CreatedAt);
            Field<CustomerType, Customer>()
                .Name("Customer")
                .Resolve(ctx => {
                    return dataSource.GetCustomerById
                    (ctx.Source.CustomerId);
                });

            Field<ListGraphType<OrderItemType>,
                IEnumerable<OrderItem>>()
                .Name("OrderItems").Resolve(ctx => 
                ctx.Source.OrderItems
                .Where(x=>x.OrderId == ctx.Source.OrderId));
                
                
        }
        
    }
}
