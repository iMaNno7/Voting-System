using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class VoterAlreadyVotedException : Exception
    {
        public VoterAlreadyVotedException(string fullName)
            : base($"voter \"{fullName}\" already voted ")
        {
        }
    }
}
