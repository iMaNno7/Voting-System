using Domain.Entities;

namespace Infrastructure.Contracts
{
    public interface IVoterVoteRepository
    {
        void AddVote(VoterVote voterVotes);
        void DeleteVote(VoterVote voterVote);
        VoterVote GetVoterVoteById(int id);
        List<VoterVote> GetVotingVotes(int votingid);
        VoterVote UpdateVote(VoterVote voterVote);
    }
}