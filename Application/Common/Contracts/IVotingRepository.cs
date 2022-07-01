using VotingEntity = Domain.Entities.Voting;
namespace Application.Common.Contracts;

public interface IVotingRepository
{
    VotingEntity GetById(int id);
    bool CheckVotingStatus(int id);
    Task<VotingEntity> Create(VotingEntity voting);
}