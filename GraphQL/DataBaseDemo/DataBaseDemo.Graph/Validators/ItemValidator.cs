using DataBaseDemo.Model;
using FluentValidation;

namespace DataBaseDemo.Graph.Validators
{
    public class ItemValidator :
    AbstractValidator<Item>
    {
        public ItemValidator()
        {
            RuleFor(i => i.Title).NotEqual("ABC");
            RuleFor(i => i.SellingPrice).GreaterThan(0);
        }
    }
}
