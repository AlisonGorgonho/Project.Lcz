using Project.Lcz.ACL.Domain.Entities;
using Project.Lcz.Models;
using Project.Lcz.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.Factorys
{
    public class ReservationFactory
    {
        public static Reserva ToAclEntity(Reservation reservation)
        {
            Reserva reserva = null;
            if (reservation != null)
            {
                reserva = new Reserva()
                {
                    Id = reservation.Id,
                    IdCliente = reservation.IdClient,
                    IdVeiculo = reservation.IdVehicle,
                    DataCriacao = reservation.CreationDate,
                    DataAtualizacao = reservation.UpdateDate,
                    DataRetirada = reservation.PickupDate,
                    DataEsperadaDevolucao = reservation.ExpectedDevolutionDate,
                    DataDevolucao = reservation.DevolutionDate
                };
            }
            return reserva;
        }

        public static List<Reserva> ToAclEntity(List<Reservation> reservations)
        {
            List<Reserva> reservas = new List<Reserva>();
            if (reservations != null && reservations.Count > 0)
            {
                foreach (var reservation in reservations)
                {
                    reservas.Add(new Reserva()
                    {
                        Id = reservation.Id,
                        IdCliente = reservation.IdClient,
                        IdVeiculo = reservation.IdVehicle,
                        DataCriacao = reservation.CreationDate,
                        DataAtualizacao = reservation.UpdateDate,
                        DataRetirada = reservation.PickupDate,
                        DataEsperadaDevolucao = reservation.ExpectedDevolutionDate,
                        DataDevolucao = reservation.DevolutionDate
                    });
                }
            }
            return reservas;
        }

        public static Reservation FromAclEntity(Reserva reserva)
        {
            Reservation reservation = null;
            if (reserva != null)
            {
                reservation = new Reservation()
                {
                    Id = reserva.Id,
                    IdClient = reserva.IdCliente,
                    IdVehicle = reserva.IdVeiculo,
                    CreationDate = reserva.DataCriacao,
                    UpdateDate = reserva.DataAtualizacao,
                    PickupDate = reserva.DataRetirada,
                    ExpectedDevolutionDate = reserva.DataEsperadaDevolucao,
                    DevolutionDate = reserva.DataDevolucao
                };
            }
            return reservation;
        }

        public static List<Reservation> FromAclEntity(List<Reserva> reservas)
        {
            List<Reservation> reservations = new List<Reservation>();
            if (reservas != null && reservas.Count > 0)
            {
                foreach (var reserva in reservas)
                {
                    reservations.Add(new Reservation()
                    {
                        Id = reserva.Id,
                        IdClient = reserva.IdCliente,
                        IdVehicle = reserva.IdVeiculo,
                        CreationDate = reserva.DataCriacao,
                        UpdateDate = reserva.DataAtualizacao,
                        PickupDate = reserva.DataRetirada,
                        ExpectedDevolutionDate = reserva.DataEsperadaDevolucao,
                        DevolutionDate = reserva.DataDevolucao
                    });
                }
            }
            return reservations;
        }

        public static Reservation ToEntity(ReservationVM reservationVM)
        {
            Reservation reservation = null;
            if (reservationVM != null)
            {
                reservation = new Reservation()
                {
                    Id = reservationVM.Id,
                    IdClient = reservationVM.IdClient,
                    IdVehicle = reservationVM.IdVehicle,
                    CreationDate = reservationVM.CreationDate,
                    UpdateDate = reservationVM.UpdateDate,
                    PickupDate = reservationVM.PickupDate,
                    ExpectedDevolutionDate = reservationVM.ExpectedDevolutionDate,
                    DevolutionDate = reservationVM.DevolutionDate
                };
            }
            return reservation;
        }

        public static List<Reservation> ToEntity(List<ReservationVM> reervationListVM)
        {
            List<Reservation> reservations = new List<Reservation>();
            if (reervationListVM != null && reervationListVM.Count > 0)
            {
                foreach (var reservationVM in reervationListVM)
                {
                    reservations.Add(new Reservation()
                    {
                        Id = reservationVM.Id,
                        IdClient = reservationVM.IdClient,
                        IdVehicle = reservationVM.IdVehicle,
                        CreationDate = reservationVM.CreationDate,
                        UpdateDate = reservationVM.UpdateDate,
                        PickupDate = reservationVM.PickupDate,
                        ExpectedDevolutionDate = reservationVM.ExpectedDevolutionDate,
                        DevolutionDate = reservationVM.DevolutionDate
                    });
                }
            }
            return reservations;
        }

        public static ReservationVM FromEntity(Reservation reservation)
        {
            ReservationVM reservationVM = null;
            if (reservation != null)
            {
                reservationVM = new ReservationVM()
                {
                    Id = reservation.Id,
                    IdClient = reservation.IdClient,
                    IdVehicle = reservation.IdVehicle,
                    CreationDate = reservation.CreationDate,
                    UpdateDate = reservation.UpdateDate,
                    PickupDate = reservation.PickupDate,
                    ExpectedDevolutionDate = reservation.ExpectedDevolutionDate,
                    DevolutionDate = reservation.DevolutionDate
                };
            }
            return reservationVM;
        }

        public static List<ReservationVM> FromEntity(List<Reservation> reservationList)
        {
            List<ReservationVM> reesrvationListVM = new List<ReservationVM>();
            if (reservationList != null && reservationList.Count > 0)
            {
                foreach (var reservation in reservationList)
                {
                    reesrvationListVM.Add(new ReservationVM()
                    {

                        Id = reservation.Id,
                        IdClient = reservation.IdClient,
                        IdVehicle = reservation.IdVehicle,
                        CreationDate = reservation.CreationDate,
                        UpdateDate = reservation.UpdateDate,
                        PickupDate = reservation.PickupDate,
                        ExpectedDevolutionDate = reservation.ExpectedDevolutionDate,
                        DevolutionDate = reservation.DevolutionDate
                    });
                }
            }
            return reesrvationListVM;
        }

        public static ReservationFilter ToEntity(ReservationFilterVM reservationFilterVM)
        {
            ReservationFilter reservationFilter = new ReservationFilter();
            if (reservationFilterVM != null)
            {
                reservationFilter = new ReservationFilter()
                {
                    StartDate = reservationFilterVM.StartDate,
                    EndDate = reservationFilterVM.EndDate
                };
            }
            return reservationFilter;
        }
    }
}
