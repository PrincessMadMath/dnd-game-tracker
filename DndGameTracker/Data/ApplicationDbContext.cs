using DndGameTracker.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DndGameTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Campaign> Campaigns { get; set; }

        public DbSet<Character> Characters { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            this.GenerateSeedData(builder);

            base.OnModelCreating(builder);
        }

        private void GenerateSeedData(ModelBuilder builder)
        {
            builder.Entity<Campaign>().HasData(
                new Campaign { Id=1, Name="Dragon Wild" }
            );

            builder.Entity<Character>().HasData(
                new Character { Id = 1, CampaignId = 1, Name = "Flynn Rider" },
                new Character { Id = 2, CampaignId = 1, Name = "Rontix Petite-Griffes" },
                new Character { Id = 3, CampaignId = 1, Name = "Zak" },
                new Character { Id = 4, CampaignId = 1, Name = "Thogorne" },
                new Character { Id = 5, CampaignId = 1, Name = "Roland Bougie" }
            );
        }
    }
}
