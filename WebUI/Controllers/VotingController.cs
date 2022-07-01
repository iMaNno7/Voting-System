using Application.Common.Contracts;
using Application.Models.Dtos;
using Application.Models.Vms;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class VotingController : ApiControllerBase
    {

        private readonly IVotingRepository _votingRepository;

        public VotingController()
        {
            _votingRepository = new VotingRepository();
        }

        [HttpPost]
        public async Task<ActionResult<Voting>> Create([FromBody] VotingDto dto)
        {
            Voting voting = dto;
            voting.AddVotingOption(dto.VotingOptions);

            var res=await _votingRepository.Create(voting);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VotingVm>> Get([FromRoute] int id)
        {
            VotingVm voting = _votingRepository.GetById(id);
            if (voting == null)
                return BadRequest("voting not exist");
            return Ok(voting);
        }
    }
}