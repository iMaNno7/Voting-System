using Application.Common.Contracts;
using Application.Models.Dtos;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class VoterController : ApiControllerBase
    {

        private readonly IVoterRepository _voterRepository;

        public VoterController()
        {
            _voterRepository = new VoterRepository();
        }

        [HttpPost]
        public async Task<ActionResult<Voter>> Create([FromBody] VoterDto dto)
        {
            if (_voterRepository.CheckEmailVoter(dto.Email))
                return BadRequest("email already exist");
            var voter = await _voterRepository.Create(dto);
            return Ok(voter);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Voter>> Get([FromRoute] int id)
        {
            var voter = _voterRepository.GetById(id);
            if (voter is null)
                return BadRequest("voter not exist");
            return Ok(voter);
        }
    }
}