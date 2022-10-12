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

        public ReservationStatus Reserve(IAreaRepository areaRepository, UserId userId)
        {
            var area = areaRepository.GetArea(new AreaId("")); // TODO

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
        public UserId(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }

    public class AreaId
    {
        public AreaId(string id)
        {
            Id = id;
        }

        public string Id { get; }

        public override string ToString()
        {
            return Id;
        }
    }

    public class Slot
    {
        public Slot(DateTime date, HourOfDay hourOfDay, SlotHourPeriod period, AreaId areaId)
        {
            Date = date;
            HourOfDay = hourOfDay;
            AreaId = areaId;
            SlotHourPeriod = period;
        }

        public DateTime Date { get; }
        public HourOfDay HourOfDay { get; }
        public AreaId AreaId { get; }
        public SlotHourPeriod SlotHourPeriod { get; }

        public string GetIdentifier()
        {
            // Slot entity needs to be uniquely identifiable and queryable
            return $"{Date.Year}{Date.Month}{Date.Day}_{HourOfDay}_{(int)SlotHourPeriod}_{AreaId}";
        }
    }

    public enum SlotHourPeriod
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4
    }

    public class HourOfDay
    {
        public HourOfDay(int hour)
        {
            if (hour < 0 || hour > 23) throw new ArgumentException("Invalid hour");

            Hour = hour;
        }

        public int Hour { get; }

        public override string ToString()
        {
            return Hour.ToString();
        }
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
