namespace Domain.Entities;

public class VoterVote
{
    public int Id{ get; set; }
    public int VoterId { get; set; }
    public int VotingOptionId { get; set; }
    public string FirstName{ get; set; }
    public string LastName{ get; set; }
    public string FullName{ get => FirstName +" "+ LastName; }
    //n.p
    public Voter Voter { get; set; }
    public VotingOption VotingOption { get; set; }
}
