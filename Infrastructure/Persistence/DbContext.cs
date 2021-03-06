using Domain.Entities;

namespace Infrastructure.Persistence
{
    public static class DbContext
    {
        static DbContext()
        {
            Voters = new List<Voter>();
            Votings = new List<Voting>();
            VoterVotes = new List<VoterVote>();
            VotingOptions = new List<VotingOption>();
        }
        public static ICollection<Voter> Voters { get; set; }
        public static ICollection<Voting> Votings { get; set; }
        public static ICollection<VoterVote> VoterVotes { get; set; }
        public static ICollection<VotingOption> VotingOptions { get; set; }
    }
}
