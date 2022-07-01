using Application.Common.Contracts;
using Domain.Entities;
using Domain.Enums;
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
        private ICollection<Voting> votings;
        static SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        public VotingRepository()
        {
            votings = DbContext.Votings;
        }

        public async Task<Voting> Create(Voting voting)
        {
            try
            {
                await semaphore.WaitAsync();
                voting.Id = votings.Count + 1;
                votings.Add(voting);
                semaphore.Release();
                return voting;
            }
            finally { }
        }

        public void AddVotingOption(int votingId, string[] options)
        {
            var voting = GetById(votingId);
            for (int i = 0; i < options.Length; i++)
                voting.AddVotingOption(options[i]);
        }

        public Voting GetById(int votingid)
             => votings.SingleOrDefault(x => x.Id == votingid);

        public bool CheckVotingStatus(int id)
            => votings.SingleOrDefault(s => s.Id == id)?.Status switch
            {
                VotingStatus.Pending => false,
                VotingStatus.Finished => false,
                VotingStatus.Started => true,
                _ => false
            };
    }
}
