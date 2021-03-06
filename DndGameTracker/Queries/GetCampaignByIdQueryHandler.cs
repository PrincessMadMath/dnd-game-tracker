﻿using DndGameTracker.Entities;
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

        public async Task<Campaign> Handle(GetCampaignByIdQuery request, CancellationToken cancellationToken)
        {
            var campaign = await this.campaignRepository.FindAsync(new object[] { request.Id }, cancellationToken);

            if(campaign == null || campaign.Deleted)
            {
                return null;
            }

            return campaign;
        }
    }
}
