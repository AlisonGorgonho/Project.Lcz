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
