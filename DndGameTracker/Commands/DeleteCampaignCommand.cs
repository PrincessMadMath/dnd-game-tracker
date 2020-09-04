using DndGameTracker.Entities;
using MediatR;

namespace DndGameTracker.Commands
{
    public class DeleteCampaignCommand : IRequest<Campaign>
    {
        public int Id { get; set; }
    }
}
