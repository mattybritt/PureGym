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
        private readonly IRepository<AreaAggregate, AreaId> areaRepository;

        public ReservationService(IRepository<SlotReservationAggregate, string> slotReservationRepository, IRepository<AreaAggregate, AreaId> areaRepository)
        {
            this.slotReservationRepository = slotReservationRepository;
            this.areaRepository = areaRepository;
        }

        public void Reserve(ReservationRequest reservation)
        {
            var slot = new Slot(reservation.Date, reservation.HourOfDay, reservation.Period, reservation.AreaId);
            var slotReservation = slotReservationRepository.TryGetById(slot.GetIdentifier());

            if (slotReservation == null)
            {
                slotReservation = SlotReservationAggregate.New(slot);
                slotReservation.Reserve(areaRepository, reservation.UserId);
                slotReservationRepository.Add(slotReservation);
            }
            else
            {
                slotReservation.Reserve(areaRepository, reservation.UserId);
                slotReservationRepository.Update(slotReservation);
            }

            //TODO return
        }
    }
}
