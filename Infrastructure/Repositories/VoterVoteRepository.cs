using Domain.Entities;
using Domain.Exceptions;
using Domain.Model;
using Infrastructure.Contracts;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class VoterVoteRepository : IVoterVoteRepository
    {
        public VoterVoteRepository()
        {
        }

        public void AddVote(VoterVote voterVotes)
        {            
            if (CheckIsVoted(voterVotes.VotingOption.VotingId, voterVotes.VoterId))
                throw new VoterAlreadyVotedException(voterVotes.Voter.FullName);

            voterVotes.Id = DbContext.VoterVotes.Count + 1;
            DbContext.VoterVotes.Add(voterVotes);
        }

        public List<VoterVote> GetVotingVotes(int votingid)
             => DbContext.VoterVotes.Where(x => x.VoterId == votingid).ToList();

        public bool CheckIsVoted(int votingid, int voterId)
             => DbContext.VoterVotes
                    .Any(x => x.VoterId == voterId&& x.VotingOption.VotingId == voterId);

        public VoterVote GetVoterVoteById(int id)
             => DbContext.VoterVotes.SingleOrDefault(x => x.Id == id);

        public VoterVote UpdateVote(VoterVote voterVote)
        {
            var voterVoteOld = GetVoterVoteById(voterVote.Id);
            voterVoteOld.VotingOption = voterVote.VotingOption;
            return voterVoteOld;
        }

        public void DeleteVote(VoterVote voterVote)
            => DbContext.VoterVotes.Remove(voterVote);
    }
}
