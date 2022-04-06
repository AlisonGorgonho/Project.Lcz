using Project.Lcz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.Services
{
    public interface IVehicleService
    {
        Vehicle CreateVehicle(Vehicle vehicle);
        Vehicle GetVehicleByLicensePlate(string licensePlate);
        List<Vehicle> GetVehiclesByFilter(VehicleFilter vehicleFilter);
    }
}
