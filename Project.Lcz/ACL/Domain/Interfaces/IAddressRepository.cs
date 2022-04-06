using Project.Lcz.ACL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.Repository.Interfaces
{
    public interface IAddressRepository
    {
        Endereco CreateClientAddress(Endereco endereco);
        Endereco UpdateClientAddress(Endereco endereco);
        Endereco GetAddresByClientId(int clienteId);
    }
}
