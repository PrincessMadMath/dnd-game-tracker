using DndGameTracker.Entities;
using MediatR;

namespace DndGameTracker.Queries
{
    public class GetCampaignByIdQuery : IRequest<Campaign>
    {
        public int Id { get; set; }
    }
}
