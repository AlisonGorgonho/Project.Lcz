using Project.Lcz.Factorys;
using Project.Lcz.Models;
using Project.Lcz.Repository.Interfaces;
using Project.Lcz.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public Reservation CreateReservation(Reservation reservation)
        {
            try
            {
                return ReservationFactory.FromAclEntity(_reservationRepository.CreateReservation(ReservationFactory.ToAclEntity(reservation)));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Reservation> GetReservationByClient(int clientId)
        {
            try
            {
                return ReservationFactory.FromAclEntity(_reservationRepository.GetReservationByClient(clientId));
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
                return _reservationRepository.GetReservationWithDevolutionDateExpired();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Reservation> GetReservationWithPickupDone(ReservationFilter reservationFilter)
        {
            try
            {
                return ReservationFactory.FromAclEntity(_reservationRepository.GetReservationWithPickupDone(reservationFilter));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Reservation UpdatePickupAndExpectedDevolutionDate(DateTime pickupDate, DateTime devolutionDate, int reservationId)
        {
            try
            {
                return ReservationFactory.FromAclEntity(_reservationRepository.UpdatePickupAndExpectedDevolutionDate(pickupDate, devolutionDate, reservationId));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Reservation UpdateDevolutionDate(DateTime devolutionDate, int reservationId)
        {
            try
            {
                return ReservationFactory.FromAclEntity(_reservationRepository.UpdateDevolutionDate(devolutionDate, reservationId));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
