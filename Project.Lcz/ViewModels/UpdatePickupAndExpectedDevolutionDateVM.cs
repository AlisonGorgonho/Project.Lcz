using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.ViewModels
{
    public class UpdatePickupAndExpectedDevolutionDateVM
    {
        public int IdReservation { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime ExpectedDevolutionDate { get; set; }
    }
}
