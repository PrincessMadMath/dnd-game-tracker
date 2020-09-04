using AutoMapper;
using DndGameTracker.Commands;
using DndGameTracker.Dtos;
using DndGameTracker.Entities;
using DndGameTracker.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DndGameTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public CampaignsController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        // GET: api/<GamesController>
        [HttpGet]
        public async Task<IEnumerable<CampaignDto>> Get()
        {
            var campaigns = await this.mediator.Send(new GetCampaignsQuery());

            return mapper.Map<IEnumerable<CampaignDto>>(campaigns);
        }

        // GET api/<GamesController>/5
        [HttpGet("{id}", Name = "GetCampaign")]
        public async Task<IActionResult> Get(int id)
        {
            var campaign = await this.mediator.Send(new GetCampaignByIdQuery { Id = id });

            if(campaign == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CampaignDto>(campaign));
        }

        // POST api/<GamesController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateCampaignCommand command)
        {
            var campaign = await this.mediator.Send(command);

            return CreatedAtAction("GetCampaign", new { campaign.Id }, mapper.Map<CampaignDto>(campaign));
        }

        // PUT api/<GamesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GamesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
