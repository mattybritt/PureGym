using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PureGym.Domain
{
    public class SlotReservationAggregate
    {
        public SlotReservationAggregate(List<UserId> reservations, Slot slot)
        {
            Reservations = reservations ?? new List<UserId>();
            Slot = slot;
        }

        public List<UserId> Reservations { get; }
        public Slot Slot { get; }

        public ReservationStatus Reserve(IAreaRepository areaRepository, UserId userId)
        {
            var area = areaRepository.GetArea(Slot.AreaId);

            if (Reservations.Count == area.AllowedSessions)
            {
                return ReservationStatus.NotAvailable;
            }
            else if (Reservations.Contains(userId))
            {
                return ReservationStatus.Reserved;
            }
            else
            {
                Reservations.Add(userId);

                return ReservationStatus.Reserved;
            }
        }
    }

}
