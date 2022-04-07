using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.ViewModels
{
    /// <summary>
    /// View Model to define ReservationVM
    /// </summary>
    public class ReservationVM
    {
        /// <summary>
        /// Id from ReservationVM
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// IdClient from ReservationVM
        /// </summary>
        public int IdClient { get; set; }
        /// <summary>
        /// IdVehicle from ReservationVM
        /// </summary>
        public int IdVehicle { get; set; }
        /// <summary>
        /// CreationDate from ReservationVM
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// UpdateDate from ReservationVM
        /// </summary>
        public DateTime UpdateDate { get; set; }
        /// <summary>
        /// PickupDate from ReservationVM
        /// </summary>
        public DateTime PickupDate { get; set; }
        /// <summary>
        /// ExpectedDevolutionDate from ReservationVM
        /// </summary>
        public DateTime ExpectedDevolutionDate { get; set; }
        /// <summary>
        /// DevolutionDate from ReservationVM
        /// </summary>
        public DateTime DevolutionDate { get; set; }
    }
}
