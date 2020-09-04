using AutoMapper;
using DndGameTracker.Entities;
using DndGameTracker.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DndGameTracker.Commands
{
    public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand, Campaign>
    {
        private readonly IMapper mapper;
        private readonly CampaignRepository campaignRepository;

        public CreateCampaignCommandHandler(IMapper mapper, CampaignRepository campaignRepository)
        {
            this.mapper = mapper;
            this.campaignRepository = campaignRepository;
        }

        public async Task<Campaign> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
        {
            var campaign = this.mapper.Map<Campaign>(request);

            return await this.campaignRepository.AddAsync(campaign, cancellationToken);
        }
    }
}
