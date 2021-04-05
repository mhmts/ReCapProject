using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(b => b.CompanyName).NotEmpty();
            RuleFor(b => b.CompanyName).MinimumLength(3);
            RuleFor(b => b.CompanyName).Must(StartWithA).WithMessage("İsimler A harfi ile başlamalı");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }

}
