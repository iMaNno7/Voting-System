

using Domain.Entities;

namespace Infrastructure.Contracts
{
    public interface IVoterRepository
    {
        void Create(Voter voter);
        Voter GetById(int voterid);
    }
}