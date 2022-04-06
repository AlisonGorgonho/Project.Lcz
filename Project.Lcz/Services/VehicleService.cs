using Project.Lcz.Factorys;
using Project.Lcz.Models;
using Project.Lcz.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public Vehicle CreateVehicle(Vehicle vehicle)
        {
            return VehicleFactory.FromAclEntity(_vehicleRepository.CreateVehicle(VehicleFactory.ToAclEntity(vehicle)));
        }

        public Vehicle GetVehicleByLicensePlate(string licensePlate)
        {
            return VehicleFactory.FromAclEntity(_vehicleRepository.GetVehicleByLicensePlate(licensePlate));
        }

        public List<Vehicle> GetVehiclesByFilter(VehicleFilter vehicleFilter)
        {
            return VehicleFactory.FromAclEntity(_vehicleRepository.GetVehicleByFilter(vehicleFilter));
        }
    }
}
