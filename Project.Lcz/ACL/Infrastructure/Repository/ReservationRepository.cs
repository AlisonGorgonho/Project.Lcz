using Microsoft.EntityFrameworkCore;
using Project.Lcz.ACL.Domain.Entities;
using Project.Lcz.Models;
using Project.Lcz.Repository.Context;
using Project.Lcz.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly SqlServerContext _context;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IClientRepository _clientRepository;

        public ReservationRepository(SqlServerContext context, IVehicleRepository vehicleRepository, IClientRepository clientRepository)
        {
            _context = context;
            _vehicleRepository = vehicleRepository;
            _clientRepository = clientRepository;
        }

        public Reserva CreateReservation(Reserva reserva)
        {
            try
            {
                if (_clientRepository.CheckIfClientExistById(reserva.IdCliente) && _vehicleRepository.CheckIfVehicleExistById(reserva.IdVeiculo))
                {
                    if (CheckIfVehicleIsAvailable(reserva.IdVeiculo))
                    {
                        _context.Reserva.Add(reserva);
                        _context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception($"O veículo selecionado para reserva não está disponível - IdVeículo: {reserva.IdVeiculo}");
                    }
                }
                else
                {
                    throw new Exception($"Não existe nenhum Client ou Veículo para os dados informados, favor verificar. IdClient: {reserva.IdCliente}, IdVeículo: {reserva.IdVeiculo}");
                }

                return reserva;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Reserva> GetReservationByClient(int clientId)
        {
            try
            {
                return _context.Reserva.Where(reserva => reserva.IdCliente.Equals(clientId))?.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Reserva> GetReservationWithPickupDone(ReservationFilter reservationFilterVM)
        {
            try
            {
                return _context.Reserva.Where(reserva => reserva.DataRetirada > reservationFilterVM.StartDate && reserva.DataRetirada < reservationFilterVM.EndDate)?.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Reserva UpdatePickupAndExpectedDevolutionDate(DateTime pickupDate, DateTime devolutionDate, int reservationId)
        {
            try
            {
                var reserva = _context.Reserva.Where(reserva => reserva.Id.Equals(reservationId))?.FirstOrDefault();
                if (reserva != null)
                {
                    reserva.DataRetirada = pickupDate;
                    reserva.DataEsperadaDevolucao = devolutionDate;

                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception($"Não existe nenhuma reserva para ser atualizada para o id informado - Id: {reservationId}");
                }
                return reserva;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Reserva UpdateDevolutionDate(DateTime devolutionDate, int reservationId)
        {
            try
            {
                var reserva = _context.Reserva.Where(reserva => reserva.Id.Equals(reservationId))?.FirstOrDefault();
                if (reserva != null)
                {
                    if (devolutionDate > reserva.DataRetirada)
                    {
                        reserva.DataDevolucao = devolutionDate;
                        _context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception($"A data de devolução não pode ser menor que a data de retirada do veículo - Data da Devolução: {devolutionDate}, Data da Retirada: {reserva.DataRetirada}");
                    }
                }
                else
                {
                    throw new Exception($"Não existe nenhuma reserva para ser atualizada para o id informado - Id: {reservationId}");
                }
                return reserva;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<string> GetReservationWithDevolutionDateExpired()
        {
            try
            {
                List<string> placasLst = new List<string>();
                List<int> vehiclesIds = new List<int>();

                var reservas = _context.Reserva.Where(reserva => reserva.DataEsperadaDevolucao < DateTime.Now)?.ToList();
                reservas.ForEach(x => vehiclesIds.Add(x.IdVeiculo));

                var veiculos = _vehicleRepository.GetVehicleByIdsList(vehiclesIds);
                veiculos.ForEach(veiculo => placasLst.Add(veiculo.Placa));

                return placasLst;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool GetReservationById(string reservationId)
        {
            try
            {
                var returnReservationById = _context.Reserva.AsNoTracking().Where(endereco => endereco.Id.Equals(reservationId)).ToList().Any();
                return returnReservationById;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool CheckIfVehicleIsAvailable(int vehicleId)
        {
            try
            {
                var vehicleAvaliabe = !_context.Reserva.AsNoTracking().Where(rl => rl.IdVeiculo.Equals(vehicleId)).ToList().Where(r => r.DataEsperadaDevolucao > DateTime.Now || r.DataDevolucao > DateTime.Now).Any();
                return vehicleAvaliabe;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
