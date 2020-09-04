using DndGameTracker.Entities;
using MediatR;

namespace DndGameTracker.Commands
{
    public class CreateCampaignCommand : IRequest<Campaign>
    {
        public string Name { get; set; }
    }
}
