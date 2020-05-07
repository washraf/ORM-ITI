using GraphQL.Types;

namespace SimpleDemo2.Model
{
    public class ItemInputType : InputObjectGraphType<Item>
    {
        public ItemInputType()
        {
            Name = "ItemInput";
            Field(i => i.Barcode);
            Field(i => i.Title);
            Field(i => i.SellingPrice);

            //Field<NonNullGraphType<StringGraphType>>("barcode");
            //Field<NonNullGraphType<StringGraphType>>("title");
            //Field<NonNullGraphType<DecimalGraphType>>("sellingPrice");
        }
    }
}
