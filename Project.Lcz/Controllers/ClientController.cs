using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Lcz.Factorys;
using Project.Lcz.Models;
using Project.Lcz.Repository.Interfaces;
using Project.Lcz.Services;
using Project.Lcz.Services.Interfaces;
using Project.Lcz.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Project.Lcz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        /// <summary>
        /// EndPoint responsible for retrieving all clients
        /// </summary>
        /// <returns></returns>
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<List<ClientVM>> GetAllClients() 
        {
            var returnClients = ClientFactory.FromEntity(_clientService.GetAllClients());
            if (returnClients != null && returnClients.Count > 0)
            {
                return Ok(returnClients);
            }
            else
            {
                return NotFound("Nenhum cliente encontrado na base de dados");
            }
        }

        /// <summary>
        /// EndPoint responsible for create a client
        /// </summary>
        /// <param name="client">Client Model for create</param>
        /// <returns></returns>
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<ClientVM> CreateClient(ClientVM client)
        {
            try
            {
                var returnClients = _clientService.CreateClient(ClientFactory.ToEntity(client));
                return Ok(returnClients);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// EndPoint responsible for retrieving clients By Part of Name and/or Full Cpf
        /// </summary>
        /// <param name="clientFilterVM">Filter contain two propertys: Name -> Part of name And Cpf -> Full Cpf</param>
        /// <returns></returns>
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("GetClientByFilter")]
        public ActionResult<List<ClientVM>> GetClientByFilter([FromBody] ClientFilterVM clientFilterVM)
        {
            var returnClients = _clientService.GetClientsByFilter(ClientFactory.ToEntity(clientFilterVM));
            if (returnClients != null && returnClients.Count > 0)
            {
                return Ok(returnClients);
            }
            else
            {
                return NotFound($"Nenhum cliente encontrado na base de dados para os seguintes parametros: 'Name' - {clientFilterVM.Name} e 'Cpf' - {clientFilterVM.Cpf}");
            }
        }

        /// <summary>
        /// EndPoint responsible for update client Address
        /// </summary>
        /// <param name="addressVM">Client Addres Model for Update</param>
        /// <returns></returns>
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("UpdateClientAddress")]
        public ActionResult<AddressVM> UpdateClientAddress([FromBody] AddressVM addressVM)
        {
            try
            {
                var returnClients = _clientService.UpdateClientAddress(AddressFactory.ToEntity(addressVM));
                return Ok(returnClients);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
