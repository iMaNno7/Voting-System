using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Model;
using Infrastructure.Contracts;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class VoterVoteController : ControllerBase
    {

        private readonly IVoterVoteRepository _voterVoteRepository;
        private readonly IVoterRepository _voterRepository;
        private readonly IVotingRepository _votingRepository;

        public VoterVoteController()
        {
            _voterVoteRepository = new VoterVoteRepository();
            _voterRepository = new VoterRepository();
            _votingRepository = new VotingRepository();
        }

        [HttpPost]
        public async Task<ActionResult> AddVote([FromBody] VoterVoteDto dto)
        {
            var voter = _voterRepository.GetById(dto.VoterId);
            var voting = _votingRepository.GetById(dto.VotingId);
            if (_votingRepository.CheckVotingStatus(dto.VotingId)) 
                throw new VotingStatusException(voting.Status);
            _voterVoteRepository.AddVote(new(voter, voting.GetVotingOption(dto.VotingOptionId)));

            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var voterVote=_voterVoteRepository.GetVoterVoteById(id);
            _voterVoteRepository.DeleteVote(voterVote);
            return Ok();
        }
    }
}