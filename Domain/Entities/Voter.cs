using Domain.Enums;

namespace Domain.Entities;

public class Voter
{
    public int Id{ get; set; }
    public string Email{ get; set; }
    public string FirstName{ get; set; }
    public string LastName{ get; set; }
    public string FullName{ get => FirstName +" "+ LastName; }
}
