using Project.Lcz.ACL.Domain.Entities;
using Project.Lcz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.Repository.Interfaces
{
    public interface IClientRepository
    {
        List<Tuple<Cliente, Endereco>> GetAllClients();
        Tuple<Cliente, Endereco> CreateClient(Cliente cliente, Endereco endereco);
        List<Tuple<Cliente, Endereco>> GetClientsByFilter(ClientFilter clientFilter);
        bool CheckIfClientExistById(int clientId);
    }
}
