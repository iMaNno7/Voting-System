using Domain.Entities;
using Domain.Enums;
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
    public class VotingRepository : IVotingRepository
    {
        public VotingRepository()
        {
        }

        public void Create(Voting voting)
        {
            voting.Id = DbContext.Votings.Count + 1;
            DbContext.Votings.Add(voting);
        }

        public void AddVotingOption(int votingId, string[] options)
        {
            var voting = GetById(votingId);
            for (int i = 0; i < options.Length; i++)
                voting.AddVotingOption(options[i]);
        }

        public Voting GetById(int votingid)
             => DbContext.Votings.SingleOrDefault(x => x.Id == votingid);

        public bool CheckVotingStatus(int id)
            => DbContext.Votings.SingleOrDefault(s => s.Id == id)?.Status switch
            {
                VotingStatus.Pending => false,
                VotingStatus.Finished => false,
                VotingStatus.Started => true,
                _ => false
            };
    }
}
