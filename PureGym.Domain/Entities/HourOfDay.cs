namespace PureGym.Domain
{
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

}
