namespace PureGym.Domain
{
    public class Area
    {
        public Area(string name, int allowedSessions)
        {
            Name = name;
            AllowedSessions = allowedSessions;
        }

        public string Name { get; }
        public int AllowedSessions { get; }
    }

}
