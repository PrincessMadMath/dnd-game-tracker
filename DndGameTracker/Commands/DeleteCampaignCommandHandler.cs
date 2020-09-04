using AutoMapper;
using DndGameTracker.Entities;
using DndGameTracker.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DndGameTracker.Commands
{
    public class DeleteCampaignCommandHandler : IRequestHandler<DeleteCampaignCommand, Campaign>
    {
        private readonly CampaignRepository campaignRepository;

        public DeleteCampaignCommandHandler(CampaignRepository campaignRepository)
        {
            this.campaignRepository = campaignRepository;
        }

        public async Task<Campaign> Handle(DeleteCampaignCommand request, CancellationToken cancellationToken)
        {
            var campaign = await this.campaignRepository.FindAsync(new object[] { request.Id }, cancellationToken);

            if(campaign == null || campaign.Deleted)
            {
                return null;
            }

            campaign.Deleted = true;

            return await this.campaignRepository.UpdateAsync(campaign, cancellationToken);
        }
    }
}
