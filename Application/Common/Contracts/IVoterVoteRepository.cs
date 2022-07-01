using Domain.Entities;

namespace Application.Common.Contracts;

public interface IVoterVoteRepository
{
    void AddVote(VoterVote voterVotes);
    bool CheckIsVoted(int votingid, int voterId);
    void DeleteVote(VoterVote voterVote);
    VoterVote GetVoterVoteById(int id);
    List<VoterVote> GetVotingVotes(int votingId);
    VoterVote UpdateVote(VoterVote voterVote);
}