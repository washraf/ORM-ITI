using DataBaseDemo.Model;
using FluentValidation;

namespace DataBaseDemo.Graph.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Name).NotEqual("ABC");
            RuleFor(c => c.Address).MinimumLength(3);
        }
    }
}
