using Microsoft.AspNetCore.Mvc;
using Project.Lcz.Factorys;
using Project.Lcz.Services.Interfaces;
using Project.Lcz.ViewModels;
using Project.Lcz.ViewModels.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public ActionResult<ReservationVM> CreateReservation([FromBody] ReservationVM reservationVM)
        {
            try
            {
                var returnClients = ReservationFactory.FromEntity(_reservationService.CreateReservation(ReservationFactory.ToEntity(reservationVM)));
                return Ok(returnClients);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<ReservationVM>> GetReservationByClient(int clientId)
        {
            var returnReservationList = ReservationFactory.FromEntity(_reservationService.GetReservationByClient(clientId));
            if (returnReservationList != null && returnReservationList.Count > 0)
            {
                return Ok(returnReservationList);
            }
            else
            {
                return NotFound($"Nenhuma reserva encontrada na base de dados para o clienteId informado - ClientId: {clientId}");
            }

        }

        [HttpPost("GetReservationWithPickupDone")]
        public ActionResult<List<ReservationVM>> GetReservationWithPickupDone([FromBody] ReservationFilterVM reservationFilterVM)
        {
            var returnReservationList = ReservationFactory.FromEntity(_reservationService.GetReservationWithPickupDone(ReservationFactory.ToEntity(reservationFilterVM)));
            if (returnReservationList != null && returnReservationList.Count > 0)
            {
                return Ok(returnReservationList);
            }
            else
            {
                return NotFound($"Nenhuma reserva encontrada na base de dados para o intervalo de data informado - Data Inicial: {reservationFilterVM.StartDate}, DataFinal: {reservationFilterVM.EndDate}");
            }
        }

        [HttpPut("UpdatePickupAndExpectedDevolutionDate")]
        public ActionResult<ReservationVM> UpdatePickupAndExpectedDevolutionDate([FromBody] UpdatePickupAndExpectedDevolutionDateVM updateModel)
        {
            try
            {
                var returnReservation = ReservationFactory.FromEntity(_reservationService.UpdatePickupAndExpectedDevolutionDate(updateModel.PickupDate, updateModel.ExpectedDevolutionDate, updateModel.IdReservation));
                return Ok(returnReservation);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        [HttpPut("UpdateDevolutionDate/devolutionDate={devolutionDate}&reservationId={reservationId}")]
        public ActionResult<ReservationVM> UpdateDevolutionDate(DateTime devolutionDate, int reservationId)
        {
            try
            {
                var returnReservation = ReservationFactory.FromEntity(_reservationService.UpdateDevolutionDate(devolutionDate, reservationId));
                return Ok(returnReservation);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        [HttpGet("GetReservationWithDevolutionDateExpired")]
        public ActionResult<List<string>> GetReservationWithDevolutionDateExpired()
        {
            var returnReservationList = _reservationService.GetReservationWithDevolutionDateExpired();
            if (returnReservationList != null && returnReservationList.Count > 0)
            {
                return Ok(returnReservationList);
            }
            else
            {
                return NotFound($"Nenhuma reserva encontrada na base de dados que tenha a data prevista de devolução expirada");
            }
        }
    }
}
