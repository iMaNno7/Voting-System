using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Dtos;

public class VoterDto
{
    [Required,RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage ="email invalid")]
    public string Email { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }

    public static implicit operator Voter(VoterDto voter)
    {
        return new()
        {
            Email = voter.Email,
            FirstName = voter.FirstName,
            LastName = voter.LastName
        };
    }
}

