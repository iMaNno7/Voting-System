using Domain.Entities;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Dtos;

public class VotingDto
{
    [Required]
    public string Subject { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public VotingStatus Status { get; set; }
    [Required]
    public string[] VotingOptions { get; set; }
    public static implicit operator Voting(VotingDto voting)
    {
        return new()
        {
            Description = voting.Description,
            Status = voting.Status,
            Subject = voting.Subject
        };
    }
}
