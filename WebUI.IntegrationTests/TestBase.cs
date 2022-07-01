using Application.Models.Dtos;
using Domain.Enums;

namespace WebUI.IntegrationTests
{
    public abstract class TestBase
    {
        public TestBase()
        {
            GenFu.GenFu.Configure<VotingDto>()
                .Fill(x => x.Status,VotingStatus.Started )
                .Fill(x => x.VotingOptions, new string[] { "a", "b", "c", "d" });
        }
    }
}
