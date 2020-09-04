using DndGameTracker.Entities;
using MediatR;

namespace DndGameTracker.Commands
{
    public class UpdateCampaignCommand : IRequest<Campaign>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
