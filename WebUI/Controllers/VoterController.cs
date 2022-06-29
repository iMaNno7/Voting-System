using Domain.Entities;
using Infrastructure.Contracts;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class VoterController : ControllerBase
    {
       
        private readonly IVoterRepository _voterRepository;

        public VoterController()
        {
            _voterRepository = new VoterRepository();
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody]Voter voter)
        {
            _voterRepository.Create(voter);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Voting>> Get([FromRoute] int id)
        {
           return Ok(_voterRepository.GetById(id));
        }
    }
}