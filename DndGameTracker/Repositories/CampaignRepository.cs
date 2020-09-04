using DndGameTracker.Data;
using DndGameTracker.Entities;

namespace DndGameTracker.Repositories
{
    public class CampaignRepository : BaseRepository<Campaign>
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CampaignRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
    }
}
