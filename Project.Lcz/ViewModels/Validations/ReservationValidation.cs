using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.ViewModels.Validations
{
    public class ReservationValidation : AbstractValidator<ReservationVM>
    {
        public ReservationValidation()
        {
            RuleFor(c => c.IdClient).NotNull().NotEmpty().NotEqual(0);
            RuleFor(c => c.IdVehicle).NotNull().NotEmpty().NotEqual(0);
            RuleFor(c => c.CreationDate).NotNull().NotEmpty();
            RuleFor(c => c.PickupDate).NotNull().NotEmpty().LessThan(p => p.ExpectedDevolutionDate);
            RuleFor(c => c.ExpectedDevolutionDate).NotNull().NotEmpty().GreaterThan(p => p.PickupDate);
            RuleFor(c => c.DevolutionDate).NotNull().NotEmpty().GreaterThanOrEqualTo(p => p.ExpectedDevolutionDate);
        }
    }
}
