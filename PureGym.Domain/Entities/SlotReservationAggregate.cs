using PureGym.Domain.Repositories;

namespace PureGym.Domain
{
    public class SlotReservationAggregate
    {
        private SlotReservationAggregate() { }

        public static SlotReservationAggregate New(Slot slot)
        {
            return new SlotReservationAggregate()
            {
                Reservations = new List<UserId>(),
                Slot = slot,
            };
        }

        public static SlotReservationAggregate Load(List<UserId> reservations, Slot slot)
        {
            return new SlotReservationAggregate()
            {
                Reservations = reservations ?? new List<UserId>(),
                Slot = slot,
            };
        }

        public List<UserId> Reservations { get; init; }
        public Slot Slot { get; init; }

        public ReservationStatus Reserve(IRepository<AreaAggregate, AreaId> areaRepository, UserId userId)
        {
            var area = areaRepository.GetById(Slot.AreaId);

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
