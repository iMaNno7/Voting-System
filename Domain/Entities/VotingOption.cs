namespace Domain.Entities;

public class VotingOption
{
    public short Id { get; set; }
    public required string Title { get; set; }
    //n.p
    public required Voting Voting { get; set; }
}
