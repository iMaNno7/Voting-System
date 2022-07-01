using Application.Common.Contracts;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class VoterRepository : IVoterRepository
    {
        private ICollection<Voter> voters;
        static SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        public VoterRepository()
        {
            voters = DbContext.Voters;
        }

        public async Task<Voter> Create(Voter voter)
        {
            try
            {
                await semaphore.WaitAsync();
                voter.Id = voters.Count + 1;
                voters.Add(voter);
                semaphore.Release();
                return voter;
            }
            finally
            {}
        }

        public bool CheckEmailVoter(string email)
            => voters.Any(s => s.Email == email);

        public Voter GetById(int voterid)
             => voters.SingleOrDefault(x => x.Id == voterid);

    }
}
