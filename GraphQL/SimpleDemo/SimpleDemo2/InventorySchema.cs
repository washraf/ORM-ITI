using GraphQL;
using GraphQL.Types;
using SimpleDemo2.Query;

namespace SimpleDemo2
{
    public class InventorySchema : Schema
    {
        public InventorySchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<InventoryQuery>();
            Mutation = resolver.Resolve<InventoryMutation>();
        }

    }
}
