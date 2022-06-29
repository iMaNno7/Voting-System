using Domain.Entities;
using Domain.Enums;

namespace Domain.Model
{
    public class VoterVoteDto
    {
        public int VoterId { get; set; }
        public int VotingId { get; set; }
        public int VotingOptionId { get; set; }
    }
}
