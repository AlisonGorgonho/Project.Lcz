using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.ViewModels.Validations
{
    public class UpdatePickupAndExpectedDevolutionDateValidation : AbstractValidator<UpdatePickupAndExpectedDevolutionDateVM>
    {
        public UpdatePickupAndExpectedDevolutionDateValidation()
        {
            RuleFor(c => c.IdReservation).NotNull().NotEmpty().NotEqual(0);
            RuleFor(c => c.PickupDate).NotNull().NotEmpty().LessThan(p => p.ExpectedDevolutionDate);
            RuleFor(c => c.ExpectedDevolutionDate).NotNull().NotEmpty().GreaterThan(p => p.PickupDate);
        }
    }
}
