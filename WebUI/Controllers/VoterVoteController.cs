using Application.Common.Contracts;
using Application.Models.Dtos;
using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class VoterVoteController : ApiControllerBase
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
        public async Task<ActionResult<bool>> AddVote([FromBody] VoterVoteDto dto)
        {
            var voter = _voterRepository.GetById(dto.VoterId);
            var voting = _votingRepository.GetById(dto.VotingId);
            if (voter is null || voting is null)
                return BadRequest();

            var option = voting.GetVotingOption(dto.VotingOptionId);
            if (_voterVoteRepository.CheckIsVoted(voting.Id, voter.Id))
                throw new VoterAlreadyVotedException(voter.FullName);

            if (_votingRepository.CheckVotingStatus(dto.VotingId) is false)
                throw new VotingStatusException(voting.Status);

            _voterVoteRepository.AddVote(new() { Voter = voter, Voting = voting, VotingOption = option });
            return Ok(true);
        }

        [HttpGet("{votingId}")]
        public async Task<ActionResult<List<VoterVote>>> GetVotingVote([FromRoute] int votingId)
        {
            var voterVotes = _voterVoteRepository.GetVotingVotes(votingId);
            return Ok(voterVotes);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var voterVote = _voterVoteRepository.GetVoterVoteById(id);
            _voterVoteRepository.DeleteVote(voterVote);
            return Ok();
        }
    }
}