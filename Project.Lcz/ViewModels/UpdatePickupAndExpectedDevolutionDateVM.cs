using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.ViewModels
{
    /// <summary>
    /// View Model to define UpdatePickupAndExpectedDevolutionDateVM
    /// </summary>
    public class UpdatePickupAndExpectedDevolutionDateVM
    {
        /// <summary>
        /// IdReservation from UpdatePickupAndExpectedDevolutionDateVM
        /// </summary>
        public int IdReservation { get; set; }
        /// <summary>
        /// PickupDate from UpdatePickupAndExpectedDevolutionDateVM
        /// </summary>
        public DateTime PickupDate { get; set; }
        /// <summary>
        /// ExpectedDevolutionDate from UpdatePickupAndExpectedDevolutionDateVM
        /// </summary>
        public DateTime ExpectedDevolutionDate { get; set; }
    }
}
