using Project.Lcz.ACL.Domain.Entities;
using Project.Lcz.Models;
using Project.Lcz.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.Factorys
{
    public class VehicleFactory
    {
        public static Veiculo ToAclEntity(Vehicle vehicle)
        {
            Veiculo veiculo = null;
            if (vehicle != null)
            {
                veiculo = new Veiculo()
                {
                    Id = vehicle.Id,
                    IdFabricante = vehicle.IdManufacturer,
                    FabricanteNome = vehicle.ManufacturerName,
                    IdModelo = vehicle.IdModel,
                    ModeloNome = vehicle.ModelName,
                    Placa = vehicle.LicensePlate
                };
            }
            return veiculo;
        }

        public static List<Veiculo> ToAclEntity(List<Vehicle> vehicles)
        {
            List<Veiculo> veiculos = new List<Veiculo>();
            if (vehicles != null && vehicles.Count > 0)
            {
                foreach (var vehicle in vehicles)
                {
                    veiculos.Add(new Veiculo()
                    {
                        Id = vehicle.Id,
                        IdFabricante = vehicle.IdManufacturer,
                        FabricanteNome = vehicle.ManufacturerName,
                        IdModelo = vehicle.IdModel,
                        ModeloNome = vehicle.ModelName,
                        Placa = vehicle.LicensePlate
                    });
                }
            }
            return veiculos;
        }

        public static Vehicle FromAclEntity(Veiculo veiculo)
        {
            Vehicle vehicle = null;
            if (veiculo != null)
            {
                vehicle = new Vehicle()
                {
                    Id = veiculo.Id,
                    IdManufacturer = veiculo.IdFabricante,
                    ManufacturerName = veiculo.FabricanteNome,
                    IdModel = veiculo.IdModelo,
                    ModelName = veiculo.ModeloNome,
                    LicensePlate = veiculo.Placa
                };
            }
            return vehicle;
        }

        public static List<Vehicle> FromAclEntity(List<Veiculo> veiculos)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            if (veiculos != null && veiculos.Count > 0)
            {
                foreach (var veiculo in veiculos)
                {
                    vehicles.Add(new Vehicle()
                    {
                        Id = veiculo.Id,
                        IdManufacturer = veiculo.IdFabricante,
                        ManufacturerName = veiculo.FabricanteNome,
                        IdModel = veiculo.IdModelo,
                        ModelName = veiculo.ModeloNome,
                        LicensePlate = veiculo.Placa
                    });
                }
            }
            return vehicles;
        }

        public static Vehicle ToEntity(VehicleVM vehicleVM)
        {
            Vehicle vehicle = null;
            if (vehicleVM != null)
            {
                vehicle = new Vehicle()
                {
                    Id = vehicleVM.Id,
                    IdManufacturer = vehicleVM.IdManufacturer,
                    ManufacturerName = vehicleVM.ManufacturerName,
                    IdModel = vehicleVM.IdModel,
                    ModelName = vehicleVM.ModelName,
                    LicensePlate = vehicleVM.LicensePlate
                };
            }
            return vehicle;
        }

        public static List<Vehicle> ToEntity(List<VehicleVM> vehicleListVM)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            if (vehicleListVM != null && vehicleListVM.Count > 0)
            {
                foreach (var vehicleVM in vehicleListVM)
                {
                    vehicles.Add(new Vehicle()
                    {
                        Id = vehicleVM.Id,
                        IdManufacturer = vehicleVM.IdManufacturer,
                        ManufacturerName = vehicleVM.ManufacturerName,
                        IdModel = vehicleVM.IdModel,
                        ModelName = vehicleVM.ModelName,
                        LicensePlate = vehicleVM.LicensePlate
                    });
                }
            }
            return vehicles;
        }

        public static VehicleVM FromEntity(Vehicle vehicle)
        {
            VehicleVM vehicleVM = null;
            if (vehicle != null)
            {
                vehicleVM = new VehicleVM()
                {
                    Id = vehicle.Id,
                    IdManufacturer = vehicle.IdManufacturer,
                    ManufacturerName = vehicle.ManufacturerName,
                    IdModel = vehicle.IdModel,
                    ModelName = vehicle.ModelName,
                    LicensePlate = vehicle.LicensePlate
                };
            }
            return vehicleVM;
        }

        public static List<VehicleVM> FromEntity(List<Vehicle> vehicleList)
        {
            List<VehicleVM> vehicleListVM = new List<VehicleVM>();
            if (vehicleList != null && vehicleList.Count > 0)
            {
                foreach (var vehicle in vehicleList)
                {
                    vehicleListVM.Add(new VehicleVM()
                    {
                        Id = vehicle.Id,
                        IdManufacturer = vehicle.IdManufacturer,
                        ManufacturerName = vehicle.ManufacturerName,
                        IdModel = vehicle.IdModel,
                        ModelName = vehicle.ModelName,
                        LicensePlate = vehicle.LicensePlate
                    });
                }
            }
            return vehicleListVM;
        }

        public static VehicleFilter ToEntity(VehicleFilterVM vehicleFilterVM)
        {
            VehicleFilter vehicleFilter = new VehicleFilter();
            if (vehicleFilterVM != null)
            {
                vehicleFilter = new VehicleFilter()
                {
                    Manufacturer = !string.IsNullOrEmpty(vehicleFilterVM.Manufacture) ? vehicleFilterVM.Manufacture : "",
                    Model = !string.IsNullOrEmpty(vehicleFilterVM.Model) ? vehicleFilterVM.Model : ""
                };
            }
            return vehicleFilter;
        }
    }
}
