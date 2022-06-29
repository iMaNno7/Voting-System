using Domain.Entities;

namespace Infrastructure.Contracts
{
    public interface IVotingRepository
    {
        void Create(Voting voting);
        Voting GetById(int id);
        bool CheckVotingStatus(int id);
    }
}