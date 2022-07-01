using Domain.Enums;

namespace Domain.Exceptions
{
    public class VotingStatusException : Exception
    {
        public VotingStatusException(VotingStatus status)
            : base($"vote status is equal to \"{status.ToString()}\" ")
        {
        }
    }
}
