using AutoMapper;
using DndGameTracker.Commands;
using DndGameTracker.Dtos;
using DndGameTracker.Entities;
using DndGameTracker.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
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

        // GET: api/<CampaignsController>
        [HttpGet]
        public async Task<IEnumerable<CampaignDto>> Get(CancellationToken cancellationToken = default)
        {
            var campaigns = await this.mediator.Send(new GetCampaignsQuery(), cancellationToken);

            return mapper.Map<IEnumerable<CampaignDto>>(campaigns);
        }

        // GET api/<CampaignsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken = default)
        {
            var campaign = await this.mediator.Send(new GetCampaignByIdQuery { Id = id }, cancellationToken);

            if(campaign == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CampaignDto>(campaign));
        }

        // POST api/<CampaignsController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateCampaignCommand command, CancellationToken cancellationToken = default)
        {
            var campaign = await this.mediator.Send(command, cancellationToken);

            return CreatedAtAction("Get", new { campaign.Id }, mapper.Map<CampaignDto>(campaign));
        }

        // PUT api/<CampaignsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateCampaignCommand command, CancellationToken cancellationToken = default)
        {
            command.Id = id;

            var campaign = await this.mediator.Send(command, cancellationToken);

            if(campaign == null)
            {
                return NotFound();
            }

            return Ok(campaign);
        }

        // DELETE api/<CampaignsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var campaign = await this.mediator.Send(new DeleteCampaignCommand { Id = id }, cancellationToken);

            if (campaign == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
