using Domain.Entities;

namespace Infrastructure.Repositories
{
    public interface IVotingRepository
    {
        void Create(Voting voting);
        Voting GetById(int id);
    }
}