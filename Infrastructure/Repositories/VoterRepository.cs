using Domain.Entities;
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
    public class VoterRepository : IVoterRepository
    {
        public VoterRepository()
        {
        }

        public void Create(Voter voter)
        {
            voter.Id = DbContext.Voters.Count + 1;
            DbContext.Voters.Add(voter);
        }

        public Voter GetById(int voterid)
             => DbContext.Voters.SingleOrDefault(x => x.Id == voterid);

    }
}
