using Project.Lcz.ACL.Domain.Entities;
using Project.Lcz.Factorys;
using Project.Lcz.Models;
using Project.Lcz.Repository.Context;
using Project.Lcz.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Project.Lcz.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly SqlServerContext _context;
        private readonly IAddressRepository _addressRepository;

        public ClientRepository(SqlServerContext context, IAddressRepository addressRepository)
        {
            _context = context;
            _addressRepository = addressRepository;
        }

        public List<Tuple<Cliente, Endereco>> GetAllClients()
        {
            try
            {
                List<Tuple<Cliente, Endereco>> clienteEEndereco = new List<Tuple<Cliente, Endereco>>();
                List<Cliente> clientes = _context.Cliente.ToList();
                foreach (var cliente in clientes)
                {
                    clienteEEndereco.Add(new Tuple<Cliente, Endereco>(cliente, _addressRepository.GetAddresByClientId(cliente.Id)));
                }
                return clienteEEndereco;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Tuple<Cliente, Endereco> CreateClient(Cliente cliente, Endereco endereco)
        {
            try
            {
                if (!CheckIfClientExistByCpf(cliente.Cpf))
                {
                    _context.Cliente.Add(cliente);
                    _context.SaveChanges();

                    if (cliente != null && cliente.Id != 0 && endereco != null)
                    {
                        endereco.IdCliente = cliente.Id;
                        _addressRepository.CreateClientAddress(endereco);
                    }
                } 
                else
                {
                    throw new Exception($"Já existe um cliente com o CPF informado - Cpf: {cliente.Cpf}");
                }

                return new Tuple<Cliente, Endereco>(cliente, endereco);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Tuple<Cliente, Endereco>> GetClientsByFilter(ClientFilter clientFilter)
        {
            try
            {
                List<Tuple<Cliente, Endereco>> clienteEEndereco = new List<Tuple<Cliente, Endereco>>();
                List<Cliente> clientes = _context.Cliente.Where(client => (!string.IsNullOrEmpty(clientFilter.Cpf) && client.Cpf.Trim().Equals(clientFilter.Cpf.Trim())) ||
                                                                          (!string.IsNullOrEmpty(clientFilter.Name) && client.Nome.Trim().Contains(clientFilter.Name.Trim()))).ToList();
                foreach (var cliente in clientes)
                {
                    clienteEEndereco.Add(new Tuple<Cliente, Endereco>(cliente, _addressRepository.GetAddresByClientId(cliente.Id)));
                }
                return clienteEEndereco;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool CheckIfClientExistByCpf(string clientCpf)
        {
            try
            {
                bool clientWithSameCpf = _context.Cliente.Where(client => client.Cpf.Equals(clientCpf)).ToList().Any();
                return clientWithSameCpf;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool CheckIfClientExistById(int clientId)
        {
            try
            {
                bool clientExistById = _context.Cliente.Where(client => client.Id.Equals(clientId)).ToList().Any();
                return clientExistById;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
