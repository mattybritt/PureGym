using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PureGym.Domain
{
    public class SlotReservationAggregate
    {
        public SlotReservationAggregate(List<UserId> reservations)
        {
            Reservations = reservations ?? new List<UserId>();
        }

        public List<UserId> Reservations { get; private set; }
        public AreaId AreaId { get; private set; }

        public ReservationStatus Reserve(IAreaRepository areaRepository, UserId userId)
        {
            var area = areaRepository.GetArea(AreaId);

            if (Reservations.Count == area.AllowedSessions)
            {
                return ReservationStatus.NotAvailable;
            }
            else if (Reservations.Contains(userId))
            {
                return ReservationStatus.AlreadyReserved;
            }
            else
            {
                Reservations.Add(userId);

                return ReservationStatus.Reserved;
            }

        }
    }

    public enum ReservationStatus
    {
        Reserved,
        AlreadyReserved,
        NotAvailable
    }


    public class UserId
    {
        public int Id { get; set; }
    }

    public class AreaId
    {
        public int Id { get; set; }
    }

    public class Slot
    {
        public DateTime Date { get; set; }
        public int HourOfDay { get; set; }
    }

    public class Area
    {
        public Area(string name, int allowedSessions)
        {
            Name = name;
            AllowedSessions = allowedSessions;
        }

        public string Name { get; set; }
        public int AllowedSessions { get; set; }
    }

    public interface IAreaRepository
    {
        Area GetArea(AreaId id);
    }

    internal class AreaRepository : IAreaRepository
    {
        public Area GetArea(AreaId id)
        {
            return new Area("Yoga", 10);
        }
    }

}
