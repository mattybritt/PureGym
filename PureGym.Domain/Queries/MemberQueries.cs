using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PureGym.Domain.Queries
{
    public class MemberQueries : IMemberQueries
    {
        public List<MemberReservationResult> GetMemberReservationsByDate(UserId userId, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
