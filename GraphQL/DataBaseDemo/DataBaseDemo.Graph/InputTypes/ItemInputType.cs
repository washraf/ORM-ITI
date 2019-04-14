using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseDemo.Graph.InputTypes
{
    public class ItemInputType : InputObjectGraphType
    {
        public ItemInputType()
        {
            Name = "ItemInput";
            Field<NonNullGraphType<StringGraphType>>("title");
            Field<NonNullGraphType<DecimalGraphType>>("SellingPrice");
        }
    }
}
