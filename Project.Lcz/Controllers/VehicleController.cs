using Microsoft.AspNetCore.Mvc;
using Project.Lcz.Factorys;
using Project.Lcz.Models;
using Project.Lcz.Services;
using Project.Lcz.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpPost]
        public ActionResult<Vehicle> CreateVehicle([FromBody] VehicleVM vehicleVM)
        {
            var returnVehicle = VehicleFactory.FromEntity(_vehicleService.CreateVehicle(VehicleFactory.ToEntity(vehicleVM)));
            return Ok(returnVehicle);
        }

        [HttpGet("GetVehicleByLicensePlate/{licensePlate}")]
        public ActionResult<Vehicle> GetVehicleByLicensePlate(string licensePlate)
        {
            var returnVehicle = VehicleFactory.FromEntity(_vehicleService.GetVehicleByLicensePlate(licensePlate));
            if (returnVehicle != null)
            {
                return Ok(returnVehicle);
            }
            else
            {
                return NotFound($"Nenhum veículo encontrado na base de dados que contenha a seguinte placa: {licensePlate}");
            }
        }

        [HttpPost("GetVehicleByFilter")]
        public ActionResult<Vehicle> GetVehicleByFilter([FromBody] VehicleFilterVM vehicleFilterVM)
        {
            var returnVehicles = VehicleFactory.FromEntity(_vehicleService.GetVehiclesByFilter(VehicleFactory.ToEntity(vehicleFilterVM)));
            if (returnVehicles != null)
            {
                return Ok(returnVehicles);
            }
            else
            {
                return NotFound($"Nenhum veículo encontrado na base de dados para os seguintes filtros - Modelo: {vehicleFilterVM.Model}, Fabricante: {vehicleFilterVM.Manufacture}");
            }
        }
    }
}
