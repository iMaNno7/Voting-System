using Domain.Entities;

namespace Application.Common.Contracts;

public interface IVoterRepository
{
    bool CheckEmailVoter(string email);
    Task<Voter> Create(Voter voter);
    Voter GetById(int voterid);
}