using DndGameTracker.Entities;
using DndGameTracker.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DndGameTracker.Commands
{
    public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand, Campaign>
    {
        private readonly CampaignRepository campaignRepository;

        public CreateCampaignCommandHandler(CampaignRepository campaignRepository)
        {
            this.campaignRepository = campaignRepository;
        }

        public async Task<Campaign> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
        {
            var campaign = new Campaign();

            return await this.campaignRepository.AddAsync(campaign, cancellationToken);
        }
    }
}
