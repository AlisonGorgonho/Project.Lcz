using Project.Lcz.ACL.Domain.Entities;
using Project.Lcz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.Repository.Interfaces
{
    public interface IVehicleRepository
    {
        Veiculo CreateVehicle(Veiculo Veiculo);
        Veiculo GetVehicleByLicensePlate(string placa);
        List<Veiculo> GetVehicleByFilter(VehicleFilter vehicleFilter);
        List<Veiculo> GetVehicleByIdsList(List<int> vehiclesIdList);
        bool CheckIfVehicleExistById(int vehicleId);
    }
}
