using PureGym.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PureGym.Domain.Service
{
    public class ReservationService
    {
        private readonly IRepository<SlotReservationAggregate, string> slotReservationRepository;

        public ReservationService(IRepository<SlotReservationAggregate, string> slotReservationRepository)
        {
            this.slotReservationRepository = slotReservationRepository;
        }

        public void Reserve(ReservationRequest reservation)
        {
            var slot = new Slot(reservation.Date, reservation.HourOfDay, reservation.Period, reservation.AreaId);
            var slotReservation = slotReservationRepository.TryGetById(slot.GetIdentifier());
        }
    }
}
