using Domain.Entities;
using Domain.Enums;

namespace Application.Models.Dtos;

public class VoterVoteDto
{
    public required int VoterId { get; set; }
    public required int VotingId { get; set; }
    public required int VotingOptionId { get; set; }
}
