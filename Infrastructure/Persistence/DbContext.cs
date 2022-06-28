using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class DbContext
    {
        public static ICollection<Voter> Voters { get; set; }
        public static ICollection<Voting> Votings { get; set; }
        public static ICollection<VoterVote> VoterVotes { get; set; }
        public static ICollection<VotingOption> VotingOptions { get; set; }
    }
}
