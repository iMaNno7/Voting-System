using Application.Models.Dtos;
using GenFu;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUI.Controllers;
using WebUI.IntegrationTests.Common;

namespace WebUI.IntegrationTests.Voting.Query;

public class GetTests : TestBase
{
    private VotingController _votingController;
    public GetTests()
    {
        _votingController = new VotingController();
    }

    [Fact]
    public async Task ShouldFindVotingById()
    {
        // can use genfu
        VotingDto createPayload = A.New<VotingDto>();
        var requestCreate = await _votingController.Create(createPayload).Val();

        var requestGet = await _votingController.Get(requestCreate.Id).Val();
        requestGet.Description.Should().Be(requestCreate.Description);
        requestGet.Id.Should().Be(requestCreate.Id);
        requestGet.VotingOptions.Length.Should().Be(requestCreate.VotingOptions.Count);
    }
}
