using Application.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.IntegrationTests
{
    public abstract class TestBase
    {
        public TestBase()
        {
            GenFu.GenFu.Configure<VotingDto>()
                .Fill(x => x.VotingOptions, new string[] { "a", "b", "c", "d" });
        }
    }
}
