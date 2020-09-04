using DndGameTracker.Entities;
using DndGameTracker.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DndGameTracker.Queries
{
    public class GetCampaignsQueryHandler : IRequestHandler<GetCampaignsQuery, IList<Campaign>>
    {
        private readonly CampaignRepository campaignRepository;

        public GetCampaignsQueryHandler(CampaignRepository campaignRepository)
        {
            this.campaignRepository = campaignRepository;
        }

        public async Task<IList<Campaign>> Handle(GetCampaignsQuery request, CancellationToken cancellationToken)
        {
            return await this.campaignRepository.GetAll().ToListAsync(cancellationToken);
        }
    }
}
