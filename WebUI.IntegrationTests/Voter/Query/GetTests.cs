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

namespace WebUI.IntegrationTests.Voter.Query
{
    public class GetTests : TestBase
    {
        private VoterController _voterController;
        public GetTests()
        {
            _voterController = new VoterController();
        }

        [Fact]
        public async Task ShouldFindVoterById()
        {
            // can use genfu
            VoterDto createPayload = A.New<VoterDto>();
            var requestCreate = await _voterController.Create(createPayload).Val();

            var requestGet = await _voterController.Get(requestCreate.Id).Val();
            requestGet.FirstName.Should().Be(requestCreate.FirstName);
            requestGet.LastName.Should().Be(requestCreate.LastName);
            requestGet.Email.Should().Be(requestCreate.Email);
        }
    }
}
