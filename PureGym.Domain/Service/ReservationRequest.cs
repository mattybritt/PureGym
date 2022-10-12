namespace PureGym.Domain
{
    public class ReservationRequest
    {
        public DateTime Date { get; internal set; }
        public HourOfDay HourOfDay { get; internal set; }
        public SlotHourPeriod Period { get; internal set; }
        public AreaId AreaId { get; internal set; }
    }
}