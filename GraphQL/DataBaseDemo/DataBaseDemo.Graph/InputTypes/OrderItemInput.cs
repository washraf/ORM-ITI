using GraphQL.Types;

namespace DataBaseDemo.Graph.InputTypes
{
    public class OrderItemInput: InputObjectGraphType
    {
        public OrderItemInput()
        {
            Field<NonNullGraphType<IntGraphType>>("ItemId");
            Field<NonNullGraphType<IntGraphType>>("Quantity");

        }
    }
}
