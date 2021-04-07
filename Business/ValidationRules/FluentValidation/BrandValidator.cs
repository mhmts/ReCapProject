using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator:AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.BrandName).NotEmpty();
            RuleFor(b => b.BrandName).MinimumLength(2);           
            RuleFor(b => b.BrandName).Must(StartWithA).WithMessage("İsimler A harfiyle başlamalı");
        }

        private bool StartWithA(string arg)
        {
          return  arg.StartsWith("A");
        }
    }

    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(c => c.CarId).NotEmpty();

        }

       
    }
}
