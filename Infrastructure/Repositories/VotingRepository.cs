﻿using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class VotingRepository
    {
        public VotingRepository()
        {
        }
        public void Create(Voting voting) {
            voting.Id=DbContext.Votings.Count+1;
            DbContext.Votings.Add(voting);
        }
        
    }
}