using Project.Lcz.ACL.Domain.Entities;
using Project.Lcz.Enums;
using Project.Lcz.Models;
using Project.Lcz.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.Factorys
{
    public class AddressFactory
    {
        public static Endereco ToAclEntity(Address address)
        {
            Endereco endereco = null;
            if (address != null)
            {
                endereco = new Endereco()
                {
                    Id = address.Id,
                    Cep = address.Cep,
                    Logradouro = address.StreetAddress,
                    Numero = address.Number,
                    Complemento = address.AddressDetails,
                    Bairro = address.District,
                    Cidade = address.City,
                    Estado = address.State,
                    TipoEndereco = (int)address.AddressType,
                    IdCliente = address.IdClient
                };
            }
            return endereco;
        }

        public static Address FromAclEntity(Endereco endereco)
        {
            Address address = null;
            if (endereco != null)
            {
                address = new Address()
                {
                    Id = endereco.Id,
                    Cep = endereco.Cep,
                    StreetAddress = endereco.Logradouro,
                    Number = endereco.Numero,
                    AddressDetails = endereco.Complemento,
                    District = endereco.Bairro,
                    City = endereco.Cidade,
                    State = endereco.Estado,
                    AddressType = (AddressType)endereco.TipoEndereco,
                    IdClient = endereco.IdCliente
                };
            }
            return address;
        }

        public static Address ToEntity(AddressVM addressVM)
        {
            Address address = null;
            if (addressVM != null)
            {
                address = new Address()
                {
                    Id = addressVM.Id,
                    Cep = addressVM.Cep,
                    StreetAddress = addressVM.StreetAddress,
                    Number = addressVM.Number,
                    AddressDetails = addressVM.AddressDetails,
                    District = addressVM.District,
                    City = addressVM.City,
                    State = addressVM.State,
                    AddressType = addressVM.AddressType,
                    IdClient = addressVM.IdClient
                };
            }
            return address;
        }

        public static AddressVM FromEntity(Address address)
        {
            AddressVM addressVM = null;
            if (address != null)
            {
                addressVM = new AddressVM()
                {
                    Id = address.Id,
                    Cep = address.Cep,
                    StreetAddress = address.StreetAddress,
                    Number = address.Number,
                    AddressDetails = address.AddressDetails,
                    District = address.District,
                    City = address.City,
                    State = address.State,
                    AddressType = address.AddressType,
                    IdClient = address.IdClient
                };
            }
            return addressVM;
        }
    }
}
