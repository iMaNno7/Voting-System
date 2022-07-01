namespace Domain.Exceptions
{
    public class VoterAlreadyVotedException : Exception
    {
        public VoterAlreadyVotedException(string fullName)
            : base($"voter \"{fullName}\" already voted ")
        {
        }
    }
}
