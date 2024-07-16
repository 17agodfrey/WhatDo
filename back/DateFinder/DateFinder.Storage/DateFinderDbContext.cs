using Microsoft.EntityFrameworkCore;
using DateFinder.Domain.Storage.EnumAttributes;
using DateFinder.Domain.Storage;


namespace DateFinder.Storage
{
    public class DateFinderDbContext : DbContext
    {
        public DbSet<Date> Dates { get; set; }

        public DateFinderDbContext(DbContextOptions<DateFinderDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure enum to be stored as string
            modelBuilder.Entity<Date>()
                .Property(d => d.ActivityLevel)
                .HasConversion<string>();

            modelBuilder.Entity<Date>()
                .Property(d => d.IndoorOutdoor)
                .HasConversion<string>();

            var dates = new List<Date>
{
    new Date { Id = Guid.NewGuid(), Name = "rock climbing", Duration = 4, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "indoor rock climbing", Duration = 2.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "amusement park", Duration = 5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "bowling", Duration = 2, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "mini golf", Duration = 2, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Both },
    new Date { Id = Guid.NewGuid(), Name = "golf", Duration = 4, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "driving range", Duration = 2, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "trampoline park", Duration = 2, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "live music", Duration = 3.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Both },
    new Date { Id = Guid.NewGuid(), Name = "zoo", Duration = 3.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "botanical garden", Duration = 2.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Both },
    new Date { Id = Guid.NewGuid(), Name = "museum", Duration = 3, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "art museum", Duration = 2.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "mall", Duration = 2, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "laser tag", Duration = 1.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "indoor scuba diving", Duration = 2.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "indoor skydiving", Duration = 1.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "ice castle", Duration = 2, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "play/musical", Duration = 3, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "beach", Duration = 4, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "butterfly", Duration = 2, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "farmers market", Duration = 1.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "movie", Duration = 3.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "drive in movie", Duration = 3.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "arcade", Duration = 1.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "ice skating", Duration = 1.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Both },
    new Date { Id = Guid.NewGuid(), Name = "mountain biking", Duration = 3, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "axe throwing", Duration = 1.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "archery", Duration = 1.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Both },
    new Date { Id = Guid.NewGuid(), Name = "boba", Duration = 1, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "ice cream", Duration = 1, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "park", Duration = 1.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "christmas lights", Duration = 1.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "pickle ball", Duration = 1.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Both },
    new Date { Id = Guid.NewGuid(), Name = "raquetball", Duration = 1.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "horseback riding", Duration = 2.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "jetskiing", Duration = 2, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "kayaking", Duration = 3.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "road trip", Duration = 5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Both },
    new Date { Id = Guid.NewGuid(), Name = "skiing", Duration = 4, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "paintballing", Duration = 3, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "skydiving", Duration = 2.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "concert", Duration = 3, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Both },
    new Date { Id = Guid.NewGuid(), Name = "air show", Duration = 5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "symphony", Duration = 2.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "hiking", Duration = 3.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
};

            modelBuilder.Entity<Date>().HasData(dates);
        }
    }
}
