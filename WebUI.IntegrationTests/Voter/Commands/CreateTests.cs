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

namespace WebUI.IntegrationTests.Voter.Commands
{
    public class CreateTests : TestBase
    {
        private VoterController _voterController;
        public CreateTests()
        {
            _voterController = new VoterController();
        }

        [Fact]
        public async Task ShouldCreateVoter()
        {
            VoterDto createPayload = A.New<VoterDto>();
            var requestCreate = await _voterController.Create(createPayload).Val();

            requestCreate.FirstName.Should().Be(createPayload.FirstName);
            requestCreate.LastName.Should().Be(createPayload.LastName);
            requestCreate.Email.Should().Be(createPayload.Email);
        }
    }
}
