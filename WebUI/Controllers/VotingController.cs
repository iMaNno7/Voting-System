using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class VotingController : ControllerBase
    {
       
        private readonly IVotingRepository _votingRepository;

        public VotingController()
        {
            _votingRepository = new VotingRepository();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Voting voting)
        {
            _votingRepository.Create(voting);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<Voting>> Get(int id)
        {
           return Ok(_votingRepository.GetById(id));
        }
    }
}