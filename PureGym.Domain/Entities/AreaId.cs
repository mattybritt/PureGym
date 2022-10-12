namespace PureGym.Domain
{
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

}
