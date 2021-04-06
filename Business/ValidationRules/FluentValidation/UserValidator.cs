using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(b => b.FirstName).NotEmpty();
            RuleFor(b => b.FirstName).MinimumLength(3);
            RuleFor(b => b.FirstName).Must(StartWithA).WithMessage("İsimler A harfiyle başlamalı");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
