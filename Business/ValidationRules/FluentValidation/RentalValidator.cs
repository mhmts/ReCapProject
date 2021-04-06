using Entities.Concrete;
using FluentValidation;


namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(c => c.RentDate).NotEmpty();
        
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
