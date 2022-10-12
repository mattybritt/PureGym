namespace PureGym.Domain.Queries
{
    public interface IMemberQueries
    {
        List<MemberReservationResult> GetMemberReservationsByDate(UserId userId, DateTime date);
    }
}