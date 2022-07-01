using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Voting
{
    public int Id { get; set; }
    public required string Subject { get; set; }
    public string? Description { get; set; }
    public required VotingStatus Status { get; set; }
    public ICollection<VotingOption> VotingOptions { get; private set; }
    public void AddVotingOption(string title)
    {
        if (VotingOptions == null) VotingOptions = new List<VotingOption>();
        if (VotingOptions.Any(x => x.Title == title) is true) throw new ArgumentException();        
        VotingOptions.Add(new VotingOption()
        {
            Title = title,
            Id = (short)(this.VotingOptions.Count + 1),
            Voting=this
        });
    }
    public void AddVotingOption(string[] title)
    {
        foreach (var item in title)
            AddVotingOption(item);
    }
    public VotingOption GetVotingOption(int id)
    =>
        this.VotingOptions.SingleOrDefault(x=>x.Id==id);
    

}

