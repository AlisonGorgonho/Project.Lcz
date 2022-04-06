using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int IdManufacturer { get; set; }
        public string ManufacturerName { get; set; }
        public int IdModel { get; set; }
        public string ModelName { get; set; }
        public string LicensePlate { get; set; }
    }
}
