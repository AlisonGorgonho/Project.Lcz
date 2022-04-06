using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.ViewModels.Validations
{
    public class VehicleValidation : AbstractValidator<VehicleVM>
    {
        public VehicleValidation()
        {
            RuleFor(c => c.IdManufacturer).NotNull().NotEmpty().NotEqual(0);
            RuleFor(c => c.ManufacturerName).NotNull().NotEmpty();
            RuleFor(c => c.IdModel).NotNull().NotEmpty().NotEqual(0);
            RuleFor(c => c.ModelName).NotNull().NotEmpty();
            RuleFor(c => c.LicensePlate).NotNull().NotEmpty();
        }
    }
}
