using AutoMapper;
using DndGameTracker.Entities;
using DndGameTracker.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DndGameTracker.Commands
{
    public class UpdateCampaignCommandHandler : IRequestHandler<UpdateCampaignCommand, Campaign>
    {
        private readonly IMapper mapper;
        private readonly CampaignRepository campaignRepository;

        public UpdateCampaignCommandHandler(IMapper mapper, CampaignRepository campaignRepository)
        {
            this.mapper = mapper;
            this.campaignRepository = campaignRepository;
        }

        public async Task<Campaign> Handle(UpdateCampaignCommand request, CancellationToken cancellationToken)
        {
            var campaign = await this.campaignRepository.FindAsync(new object[] { request.Id }, cancellationToken);

            if(campaign == null)
            {
                return null;
            }

            this.mapper.Map(request, campaign);

            return await this.campaignRepository.UpdateAsync(campaign, cancellationToken);
        }
    }
}
