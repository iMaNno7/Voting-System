namespace Domain.Entities;

public class VoterVote
{
    public VoterVote()
    {
    }
    public int Id { get; set; }
    public required Voter Voter { get; set; }
    public required Voting Voting { get; set; }
    public required VotingOption VotingOption { get; set; }
}
