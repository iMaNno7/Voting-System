namespace Domain.Entities;

public class VotingOption
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int VotingId { get; set; }
    //n.p
    public Voting Voting { get; set; }
}
