using Project.Lcz.ACL.Domain.Entities;
using Project.Lcz.Models;
using Project.Lcz.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.Factorys
{
    public class ClientFactory
    {
        public static Cliente ToAclEntity(Client client)
        {
            Cliente cliente = null;
            if (client != null)
            {
                cliente = new Cliente()
                {
                    Id = client.Id,
                    Cpf = client.Cpf,
                    Nome = client.Name,
                    DataNascimento = client.BirthDate,
                    CnhNumero = client.CnhNumber
                };
            }
            return cliente;
        }

        public static List<Cliente> ToAclEntity(List<Client> clients)
        {
            List<Cliente> clientes = new List<Cliente>();
            if (clients != null && clients.Count > 0)
            {
                foreach (var client in clients)
                {
                    clientes.Add(new Cliente()
                    {
                        Id = client.Id,
                        Cpf = client.Cpf,
                        Nome = client.Name,
                        DataNascimento = client.BirthDate,
                        CnhNumero = client.CnhNumber
                    });
                }
            }
            return clientes;
        }

        public static Client FromAclEntity(Cliente cliente)
        {
            Client client = null;
            if (cliente != null)
            {
                client = new Client()
                {
                    Id = cliente.Id,
                    Name = cliente.Nome,
                    Cpf = cliente.Cpf,
                    BirthDate = cliente.DataNascimento,
                    CnhNumber = cliente.CnhNumero
                };
            }
            return client;
        }

        public static List<Client> FromAclEntity(List<Cliente> clientes)
        {
            List<Client> clients = new List<Client>();
            if (clientes != null && clientes.Count > 0)
            {
                foreach (var cliente in clientes)
                {
                    clients.Add(new Client()
                    {
                        Id = cliente.Id,
                        Name = cliente.Nome,
                        Cpf = cliente.Cpf,
                        BirthDate = cliente.DataNascimento,
                        CnhNumber = cliente.CnhNumero
                    });
                }
            }
            return clients;
        }

        public static Client FromAclEntity(Cliente cliente, Endereco endereco)
        {
            Client client = null;
            if (cliente != null)
            {
                client = new Client()
                {
                    Id = cliente.Id,
                    Name = cliente.Nome,
                    Cpf = cliente.Cpf,
                    BirthDate = cliente.DataNascimento,
                    CnhNumber = cliente.CnhNumero,
                    Address = endereco != null ? AddressFactory.FromAclEntity(endereco) : null
                };
            }
            return client;
        }

        public static Client ToEntity(ClientVM clientVM)
        {
            Client client = null;
            if (clientVM != null)
            {
                client = new Client()
                {
                    Id = clientVM.Id,
                    Name = clientVM.Name,
                    Cpf = clientVM.Cpf,
                    BirthDate = clientVM.BirthDate,
                    CnhNumber = clientVM.CnhNumber,
                    Address = AddressFactory.ToEntity(clientVM.Address)
                };
            }
            return client;
        }

        public static List<Client> ToEntity(List<ClientVM> clientListVM)
        {
            List<Client> clients = new List<Client>();
            if (clientListVM != null && clientListVM.Count > 0)
            {
                foreach (var clientVM in clientListVM)
                {
                    clients.Add(new Client()
                    {
                        Id = clientVM.Id,
                        Name = clientVM.Name,
                        Cpf = clientVM.Cpf,
                        BirthDate = clientVM.BirthDate,
                        CnhNumber = clientVM.CnhNumber,
                        Address = AddressFactory.ToEntity(clientVM.Address)
                    });
                }
            }
            return clients;
        }

        public static ClientVM FromEntity(Client client)
        {
            ClientVM clientVM = null;
            if (client != null)
            {
                clientVM = new ClientVM()
                {
                    Id = client.Id,
                    Name = client.Name,
                    Cpf = client.Cpf,
                    BirthDate = client.BirthDate,
                    CnhNumber = client.CnhNumber,
                    Address = AddressFactory.FromEntity(client.Address)
                };
            }
            return clientVM;
        }

        public static List<ClientVM> FromEntity(List<Client> clientList)
        {
            List<ClientVM> clientListVM = new List<ClientVM>();
            if (clientList != null && clientList.Count > 0)
            {
                foreach (var client in clientList)
                {
                    clientListVM.Add(new ClientVM()
                    {
                        Id = client.Id,
                        Name = client.Name,
                        Cpf = client.Cpf,
                        BirthDate = client.BirthDate,
                        CnhNumber = client.CnhNumber,
                        Address = AddressFactory.FromEntity(client.Address)
                    });
                }
            }
            return clientListVM;
        }

        public static ClientFilter ToEntity(ClientFilterVM clientFilterVM)
        {
            ClientFilter clientFilter = new ClientFilter();
            if (clientFilterVM != null)
            {
                clientFilter = new ClientFilter()
                {
                    Cpf = clientFilterVM.Cpf,
                    Name = clientFilterVM.Name
                };
            }
            return clientFilter;
        }
    }
}
