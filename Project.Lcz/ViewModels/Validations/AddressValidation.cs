using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.ViewModels.Validations
{
    public class AddressValidation : AbstractValidator<AddressVM>
    {
        public AddressValidation()
        {
            RuleFor(c => c.Cep).NotNull().NotEmpty();
            RuleFor(c => c.StreetAddress).NotNull().NotEmpty();
            RuleFor(c => c.Number).NotNull().NotEmpty();
            RuleFor(c => c.AddressDetails).NotNull().NotEmpty();
            RuleFor(c => c.District).NotNull().NotEmpty();
            RuleFor(c => c.City).NotNull().NotEmpty();
            RuleFor(c => c.State).NotNull().NotEmpty();
            RuleFor(c => c.AddressType).NotNull();
        }
    }
}
