using Domain.Entities;
using Domain.Enums;

namespace Domain.Model
{
    public class VotingDto
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public VotingStatus Status { get; set; }
        public static implicit operator Voting(VotingDto voting)
        {
            return new()
            {
                Description = voting.Description,
                Id = voting.Id,
                Status = voting.Status,
                Subject = voting.Subject
            };
        }
    }
}
