using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseDemo.Graph.InputTypes
{
    public class CustomerInput: InputObjectGraphType
    {
        public CustomerInput()
        {
            Name = "CustomerInput";
            Field<NonNullGraphType<StringGraphType>>("Name");
            Field<NonNullGraphType<StringGraphType>>("Address");
            Field<ListGraphType<OrderInput>>("Orders");
        }
    }
}
