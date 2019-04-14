using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseDemo.Graph.Filter
{
    public class CustomerQueryFilter:
        InputObjectGraphType<CustomerQuery>
    {
        public CustomerQueryFilter()
        {
            Field(i => i.SortField,nullable:true);
            Field(i => i.SortDirection,nullable:true);
            Field(i => i.PageSize,nullable:true);
            Field(i => i.PageNumber, nullable: true);
            Field(i => i.CustomerName,nullable:true);
        }
    }

    public class CustomerQuery
    {
        public string SortField { get; set; }
        public int SortDirection { get; set; }
        public int PageSize { get; set; } = 50;
        public int PageNumber { get; set; } = 0;

        public string CustomerName { get; set; }
    }
}
