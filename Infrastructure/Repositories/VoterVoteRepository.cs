using Application.Common.Contracts;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class VoterVoteRepository : IVoterVoteRepository
    {
        private ICollection<VoterVote> voterVotes;
        public VoterVoteRepository()
        {
            voterVotes = DbContext.VoterVotes;
        }

        public void AddVote(VoterVote voterVotes)
        {
            voterVotes.Id = this.voterVotes.Count + 1;
            this.voterVotes.Add(voterVotes);
        }

        public List<VoterVote> GetVotingVotes(int votingid)
             => voterVotes.Where(x => x.Voter.Id == votingid).ToList();

        public bool CheckIsVoted(int votingid, int voterId)
             => voterVotes
                    .Any(x => x.Voter.Id == voterId && x.VotingOption.Voting.Id == votingid);

        public VoterVote GetVoterVoteById(int id)
             => voterVotes.SingleOrDefault(x => x.Id == id);

        public VoterVote UpdateVote(VoterVote voterVote)
        {
            var voterVoteOld = GetVoterVoteById(voterVote.Id);
            voterVoteOld.VotingOption = voterVote.VotingOption;
            return voterVoteOld;
        }

        public void DeleteVote(VoterVote voterVote)
            => voterVotes.Remove(voterVote);
    }
}
