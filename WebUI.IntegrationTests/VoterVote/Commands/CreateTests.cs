using Application.Models.Dtos;
using Domain.Enums;
using Domain.Exceptions;
using GenFu;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUI.Controllers;
using WebUI.IntegrationTests.Common;

namespace WebUI.IntegrationTests.VoterVote.Commands;

public class CreateTests : TestBase
{
    private VotingController _votingController;
    private VoterController _voterController;
    private VoterVoteController _voterVoteController;
    public CreateTests()
    {
        _votingController = new();
        _voterVoteController = new();
        _voterController = new();
    }


    [Fact]
    public async Task ShouldThrowVoterAlreadyVotedException()
    {
        VotingDto createVotingPayload = GenFu.GenFu.New<VotingDto>();
        var requestVotingCreate = await _votingController.Create(createVotingPayload).Val();

        VoterDto createVoterPayload = A.New<VoterDto>();
        var requestVoterCreate = await _voterController.Create(createVoterPayload).Val();

        var requestCreate = await _voterVoteController.AddVote(new()
        {
            VoterId = requestVoterCreate.Id,
            VotingId = requestVotingCreate.Id,
            VotingOptionId = requestVotingCreate.VotingOptions.First().Id
        });
        await FluentActions.Invoking(() =>
        _voterVoteController.AddVote(new()
        {
            VoterId = requestVoterCreate.Id,
            VotingId = requestVotingCreate.Id,
            VotingOptionId = requestVotingCreate.VotingOptions.First().Id
        })).Should().ThrowAsync<VoterAlreadyVotedException>();

    }

    [Fact]
    public async Task ShouldCreateVotingAndVoterThenAddVote()
    {
        VotingDto createVotingPayload = GenFu.GenFu.New<VotingDto>();
        var requestVotingCreate = await _votingController.Create(createVotingPayload).Val();

        VoterDto createVoterPayload = A.New<VoterDto>();
        var requestVoterCreate = await _voterController.Create(createVoterPayload).Val();

        var requestCreate = await _voterVoteController.AddVote(new()
        {
            VoterId = requestVoterCreate.Id,
            VotingId = requestVotingCreate.Id,
            VotingOptionId = requestVotingCreate.VotingOptions.First().Id
        });
        Assert.IsType<OkObjectResult>(requestCreate.Result);
    }
}