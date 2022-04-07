using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.ViewModels
{
    /// <summary>
    /// View Model to define VehicleVM
    /// </summary>
    public class VehicleVM
    {
        /// <summary>
        /// Id from VehicleVM
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// IdManufacturer from VehicleVM
        /// </summary>
        public int IdManufacturer { get; set; }
        /// <summary>
        /// ManufacturerName from VehicleVM
        /// </summary>
        public string ManufacturerName { get; set; }
        /// <summary>
        /// IdModel from VehicleVM
        /// </summary>
        public int IdModel { get; set; }
        /// <summary>
        /// ModelName from VehicleVM
        /// </summary>
        public string ModelName { get; set; }
        /// <summary>
        /// LicensePlate from VehicleVM
        /// </summary>
        public string LicensePlate { get; set; }
    }
}
