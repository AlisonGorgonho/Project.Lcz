using Microsoft.EntityFrameworkCore;
using Project.Lcz.ACL.Domain.Entities;
using Project.Lcz.Models;
using Project.Lcz.Repository.Context;
using Project.Lcz.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly SqlServerContext _context;

        public VehicleRepository(SqlServerContext context)
        {
            _context = context;
        }

        public Veiculo CreateVehicle(Veiculo veiculo)
        {
            try
            {
                _context.Veiculo.Add(veiculo);
                _context.SaveChanges();

                return veiculo;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Veiculo> GetVehicleByFilter(VehicleFilter vehicleFilter)
        {
            try
            {
                return _context.Veiculo.Where(veiculo => veiculo.FabricanteNome.Equals(vehicleFilter.Manufacturer) || veiculo.ModeloNome.Equals(vehicleFilter.Model))?.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Veiculo GetVehicleByLicensePlate(string placa)
        {
            try
            {
                return _context.Veiculo.Where(veiculo => veiculo.Placa.Equals(placa))?.FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Veiculo> GetVehicleByIdsList(List<int> vehiclesIdList)
        {
            try
            {
                return _context.Veiculo.Where(veiculo => vehiclesIdList.Contains(veiculo.Id))?.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool CheckIfVehicleExistById(int vehicleId)
        {
            try
            {
                var returnVehicleById = _context.Veiculo.AsNoTracking().Where(vehicle => vehicle.Id.Equals(vehicleId)).ToList().Any();
                return returnVehicleById;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
