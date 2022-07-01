using Domain.Entities;
using Domain.Enums;

namespace Application.Models.Vms;

public class VotingVm
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
    public VotingStatus Status { get; set; }
    public VotingOptionVm[] VotingOptions { get; set; }
    public static implicit operator VotingVm(Voting voting)
    {
        return new()
        {
            Id = voting.Id,
            Description = voting.Description,
            Status = voting.Status,
            Subject = voting.Subject,
            VotingOptions = voting.VotingOptions.Select<VotingOption, VotingOptionVm>(s => s).ToArray()
        };
    }
}
public class VotingOptionVm
{
    public int Id { get; set; }
    public string Title { get; set; }

    public static implicit operator VotingOptionVm(VotingOption option)
        => new()
        {
            Id = option.Id,
            Title = option.Title
        };

}
