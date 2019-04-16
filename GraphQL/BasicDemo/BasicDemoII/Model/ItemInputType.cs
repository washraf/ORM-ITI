using GraphQL.Types;

namespace BasicDemoII.Model
{
    //public class ItemInputType : InputObjectGraphType
    //{
    //    public ItemInputType()
    //    {
    //        Name = "ItemInput";
    //        Field<NonNullGraphType<StringGraphType>>("barcode");
    //        Field<NonNullGraphType<StringGraphType>>("title");
    //        Field<NonNullGraphType<DecimalGraphType>>("sellingPrice");
    //    }
    //}
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
