using Project.Lcz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.Services.Interfaces
{
    public interface IClientService
    {
        List<Client> GetAllClients();
        Client CreateClient(Client client);
        List<Client> GetClientsByFilter(ClientFilter clientFilter);
        Address UpdateClientAddress(Address address);
    }
}
