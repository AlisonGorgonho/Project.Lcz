using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Lcz.Factorys;
using Project.Lcz.Services.Interfaces;
using Project.Lcz.ViewModels;
using Project.Lcz.ViewModels.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
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

        /// <summary>
        /// EndPoint responsible for create a Reservation
        /// </summary>
        /// <param name="reservationVM">Reservation</param>
        /// <returns></returns>
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// EndPoint responsible for retrieving reservation list by Client ID
        /// </summary>
        /// <param name="clientId">Client ID</param>
        /// <returns></returns>
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// EndPoint responsible for retrieving reservation list with pickup done in range date specified
        /// </summary>
        /// <param name="reservationFilterVM">Filter contain two propertys: Start Date -> Inicial date of range And End Date -> Final Data of range</param>
        /// <returns></returns>
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// EndPoint responsible for update pickup date and ExpectedDevolution date from a reservation
        /// </summary>
        /// <param name="updateModel">ModelVM contain tree propertys: IdReservation -> Id generated in reservation create, PickupDate -> PickupDate for update in reservation And ExpectedDevolutionDate -> ExpectedDevolutionDate for update in reservation</param>
        /// <returns></returns>
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// EndPoint responsible for update devolution date from a reservation
        /// </summary>
        /// <param name="devolutionDate">DevolutionDate -> Devolution date for update in reservation</param>
        /// <param name="reservationId">ReservationId -> Id generated in reservation create</param>
        /// <returns></returns>
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// EndPoint responsible for retrieving reservation with devolution date expired
        /// </summary>
        /// <returns></returns>
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
