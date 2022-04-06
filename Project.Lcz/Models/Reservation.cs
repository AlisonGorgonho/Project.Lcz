using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public int IdVehicle { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime ExpectedDevolutionDate { get; set; }
        public DateTime DevolutionDate { get; set; }
    }
}
