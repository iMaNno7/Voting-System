namespace Domain.Entities;

public class Voter
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string FullName { get => FirstName + " " + LastName; }
}
