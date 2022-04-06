using Project.Lcz.Models;
using Project.Lcz.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Lcz.Services.Interfaces
{
    public interface IReservationService
    {
        Reservation CreateReservation(Reservation reservation);
        List<Reservation> GetReservationByClient(int clientId);
        List<Reservation> GetReservationWithPickupDone(ReservationFilter reservationFilter);
        Reservation UpdatePickupAndExpectedDevolutionDate(DateTime pickupDate, DateTime devolutionDate, int reservationId);
        Reservation UpdateDevolutionDate(DateTime devolutionDate, int reservationId);
        List<string> GetReservationWithDevolutionDateExpired();
    }
}
