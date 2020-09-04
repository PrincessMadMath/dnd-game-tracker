using DndGameTracker.Entities;
using DndGameTracker.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DndGameTracker.Queries
{
    public class GetCampaignByIdQueryHandler : IRequestHandler<GetCampaignByIdQuery, Campaign>
    {
        private readonly CampaignRepository campaignRepository;

        public GetCampaignByIdQueryHandler(CampaignRepository campaignRepository)
        {
            this.campaignRepository = campaignRepository;
        }

        public Task<Campaign> Handle(GetCampaignByIdQuery request, CancellationToken cancellationToken)
        {
            return this.campaignRepository.FindAsync(new object[] { request.Id }, cancellationToken);
        }
    }
}
