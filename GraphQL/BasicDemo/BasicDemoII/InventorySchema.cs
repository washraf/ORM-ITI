using BasicDemoII.Query;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicDemoII
{
    public class InventorySchema: Schema
    {
        public InventorySchema(IDependencyResolver resolver) 
            : base(resolver)
        {
            Query = resolver.Resolve<InventoryQuery>();
            Mutation = resolver.Resolve<InventoryMutation>();
        }
        
    }
}
