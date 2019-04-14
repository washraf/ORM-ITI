using GraphQL.Types;

namespace DataBaseDemo.Graph.InputTypes
{
    public class OrderInput: InputObjectGraphType
    {
       
        public OrderInput()
        {
            Field<NonNullGraphType<StringGraphType>>("Tag");
            Field<ListGraphType<OrderItemInput>>("OrderItems");
        }
    }
}
