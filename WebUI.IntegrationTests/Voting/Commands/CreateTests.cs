using Application.Models.Dtos;
using Domain.Enums;
using GenFu;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUI.Controllers;
using WebUI.IntegrationTests.Common;

namespace WebUI.IntegrationTests.Voting.Commands;

public class CreateTests : TestBase
{
    private VotingController _votingController;
    public CreateTests()
    {
        _votingController = new VotingController();
        A.Configure<VotingDto>()
            .Fill(x => x.VotingOptions, new string[] { "a", "b", "c", "d" });
    }

    [Fact]
    public async Task ShouldCreateVoting()
    {
        // can use genfu
        VotingDto createPayload = A.New<VotingDto>();
        var requestCreate = await _votingController.Create(createPayload).Val();

        requestCreate.Status.Should().Be(createPayload.Status);
        requestCreate.Subject.Should().Be(createPayload.Subject);
        requestCreate.Description.Should().Be(createPayload.Description);
        requestCreate.VotingOptions.Count.Should().Be(createPayload.VotingOptions.Length);
    }
}