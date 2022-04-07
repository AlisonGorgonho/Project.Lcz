using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.ViewModels
{
    /// <summary>
    /// View Model to define ReservationFilterVM
    /// </summary>
    public class ReservationFilterVM
    {
        /// <summary>
        /// StartDate from ReservationFilterVM
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// EndDate from ReservationFilterVM
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}
