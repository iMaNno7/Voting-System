using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class VotingStatusException : Exception
    {
        public VotingStatusException(VotingStatus status)
            : base($"vote status is equal to \"{status.ToString()}\" ")
        {
        }
    }
}
