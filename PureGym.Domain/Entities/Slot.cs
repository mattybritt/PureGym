namespace PureGym.Domain
{
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

}
