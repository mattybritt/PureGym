namespace PureGym.Domain
{
    public class AreaAggregate
    {
        public AreaAggregate(AreaId areaId, string name, int allowedSessions)
        {
            AreaId = areaId;
            Name = name;
            AllowedSessions = allowedSessions;
        }

        public AreaId AreaId { get; }
        public string Name { get; }
        public int AllowedSessions { get; }
    }

}
