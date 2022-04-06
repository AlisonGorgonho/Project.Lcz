using Project.Lcz.ACL.Domain.Entities;
using Project.Lcz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.Repository.Interfaces
{
    public interface IReservationRepository
    {
        Reserva CreateReservation(Reserva reservationVM);
        List<Reserva> GetReservationByClient(int clientId);
        List<Reserva> GetReservationWithPickupDone(ReservationFilter reservationFilterVM);
        Reserva UpdatePickupAndExpectedDevolutionDate(DateTime pickupDate, DateTime devolutionDate, int reservationId);
        Reserva UpdateDevolutionDate(DateTime devolutionDate, int reservationId);
        List<string> GetReservationWithDevolutionDateExpired();
    }
}
