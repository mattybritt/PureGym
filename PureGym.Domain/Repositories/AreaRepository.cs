namespace PureGym.Domain
{
    internal class AreaRepository : IAreaRepository
    {
        public Area GetArea(AreaId id)
        {
            return new Area("Yoga", 10);
        }
    }

}
