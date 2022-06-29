namespace Domain.Entities;

public class VoterVote
{
    public VoterVote(Voter voter,VotingOption votingOption)
    {
        this.Voter=voter;
        this.VotingOption=votingOption;
        this.VoterId=voter.Id;
        this.VotingOptionId = votingOption.Id;
    }
    public int Id{ get; set; }
    public int VoterId { get; set; }
    public int VotingOptionId { get; set; }
    //n.p
    public Voter Voter { get; set; }
    public VotingOption VotingOption { get; set; }
}
