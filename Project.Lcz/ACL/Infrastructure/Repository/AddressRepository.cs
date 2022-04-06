using Microsoft.EntityFrameworkCore;
using Project.Lcz.ACL.Domain.Entities;
using Project.Lcz.Repository.Context;
using Project.Lcz.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly SqlServerContext _context;

        public AddressRepository(SqlServerContext context)
        {
            _context = context;
        }

        public Endereco CreateClientAddress(Endereco endereco)
        {
            try
            {
                _context.Endereco.Add(endereco);
                _context.SaveChanges();
                return endereco;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Endereco UpdateClientAddress(Endereco endereco)
        {
            try
            {
                if (CheckIfAddressExist(endereco.Id))
                {
                    _context.Endereco.Update(endereco);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception($"Não existe um endereco para o id informado - Id: {endereco.Id}");
                }

                return endereco;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Endereco GetAddresByClientId(int clienteId)
        {
            try
            {
                return _context.Endereco.FirstOrDefault(endereco => endereco.IdCliente.Equals(clienteId));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool CheckIfAddressExist(int enderecoId)
        {
            try
            {
                var returnAddresById = _context.Endereco.AsNoTracking().Where(endereco => endereco.Id.Equals(enderecoId)).ToList().Any();
                return returnAddresById;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
