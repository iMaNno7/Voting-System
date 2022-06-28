using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Voting
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
    public VotingStatus Status { get; set; }
    public ICollection<VotingOption> VotingOptions { get; private set; }
    public void AddVotingOption(string title)
    {
        if (VotingOptions == null) VotingOptions = new List<VotingOption>();
        VotingOptions.Add(new()
        {
            Id = this.VotingOptions.Count + 1,
            Title = title
        });
    }
}
