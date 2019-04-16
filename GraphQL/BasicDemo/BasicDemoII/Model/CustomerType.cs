using GraphQL.Types;
using System.Collections.Generic;

namespace BasicDemoII.Model
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType(DataSource dataSource)
        {
            Field(c => c.CustomerId);
            Field(c => c.Name);
            Field(c => c.BillingAddress);
            Field<ListGraphType<OrderType>, IEnumerable<Order>>()
                .Name("Orders")
                .Resolve(ctx => {
                    return dataSource.GetOrdersByCustomerId
                    (ctx.Source.CustomerId);
                });
        }
    }
}
