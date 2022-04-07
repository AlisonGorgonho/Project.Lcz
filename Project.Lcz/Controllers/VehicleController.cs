using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Lcz.Factorys;
using Project.Lcz.Models;
using Project.Lcz.Services;
using Project.Lcz.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
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

        /// <summary>
        /// EndPoint responsible for create a vehicle
        /// </summary>
        /// <param name="vehicleVM">Vehicle Model for Create</param>
        /// <returns></returns>
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Vehicle> CreateVehicle([FromBody] VehicleVM vehicleVM)
        {
            var returnVehicle = VehicleFactory.FromEntity(_vehicleService.CreateVehicle(VehicleFactory.ToEntity(vehicleVM)));
            return Ok(returnVehicle);
        }


        /// <summary>
        /// EndPoint responsible for get vehicle by licensePlate
        /// </summary>
        /// <param name="licensePlate">LicensePlate for search vehicle</param>
        /// <returns></returns>
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
                return NotFound($"Nenhum veículo encontrado na base pela busca da seguinte placa: {licensePlate}");
            }
        }

        /// <summary>
        /// EndPoint responsible for get vehicle by manufacturer and/or model
        /// </summary>
        /// <param name="vehicleFilterVM">Filter contain two propertys: Model -> Model of Vehicle And Manufacturer -> Manufacturer of Vehicle
        /// </param>
        /// <returns></returns>
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
