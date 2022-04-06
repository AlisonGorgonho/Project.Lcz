using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.ViewModels.Validations
{
    public class ClientValidation : AbstractValidator<ClientVM>
    {
        public ClientValidation()
        {
            RuleFor(c => c.Id).NotNull().Equal(0);
            RuleFor(c => c.Name).NotNull().NotEmpty();
            RuleFor(c => c.Cpf).NotNull().NotEmpty();
            RuleFor(c => c.BirthDate).NotNull().NotEmpty();
            RuleFor(c => c.CnhNumber).NotNull().NotEmpty();
            RuleFor(c => c.Address).NotNull().NotEmpty().SetValidator(new AddressValidation());
        }
    }
}
