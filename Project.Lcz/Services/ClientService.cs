using Project.Lcz.ACL.Domain.Entities;
using Project.Lcz.Factorys;
using Project.Lcz.Models;
using Project.Lcz.Repository;
using Project.Lcz.Repository.Interfaces;
using Project.Lcz.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Project.Lcz.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IAddressRepository _addressRepository;

        public ClientService(IClientRepository clientRepository, IAddressRepository addressRepository)
        {
            _clientRepository = clientRepository;
            _addressRepository = addressRepository;
        }

        public List<Client> GetAllClients()
        {
            try
            {
                List<Client> clients = new List<Client>();
                List<Tuple<Cliente, Endereco>> clientsWithAddress = _clientRepository.GetAllClients();

                foreach (var clientWithAddress in clientsWithAddress)
                {
                    Cliente clienteRecord = new Cliente();
                    Endereco enderecoRecord = new Endereco();

                    (clienteRecord, enderecoRecord) = clientWithAddress;
                    clients.Add(ClientFactory.FromAclEntity(clienteRecord, enderecoRecord));
                }
                return clients;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Client CreateClient(Client client)
        {
            try
            {
                Cliente clienteRecord = new Cliente();
                Endereco enderecoRecord = new Endereco();

                (clienteRecord, enderecoRecord) = _clientRepository.CreateClient(ClientFactory.ToAclEntity(client), AddressFactory.ToAclEntity(client.Address));
                return ClientFactory.FromAclEntity(clienteRecord, enderecoRecord);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Client> GetClientsByFilter(ClientFilter clientFilter)
        {
            try
            {
                List<Client> clients = new List<Client>();
                List<Tuple<Cliente, Endereco>> clientsWithAddress = _clientRepository.GetClientsByFilter(clientFilter);

                foreach (var clientWithAddress in clientsWithAddress)
                {
                    Cliente clienteRecord = new Cliente();
                    Endereco enderecoRecord = new Endereco();

                    (clienteRecord, enderecoRecord) = clientWithAddress;
                    clients.Add(ClientFactory.FromAclEntity(clienteRecord, enderecoRecord));
                }
                return clients;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Address CreateClientAddress(Address address)
        {
            try
            {
                return AddressFactory.FromAclEntity(_addressRepository.CreateClientAddress(AddressFactory.ToAclEntity(address)));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Address UpdateClientAddress(Address address)
        {
            try
            {
                return AddressFactory.FromAclEntity(_addressRepository.UpdateClientAddress(AddressFactory.ToAclEntity(address)));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
