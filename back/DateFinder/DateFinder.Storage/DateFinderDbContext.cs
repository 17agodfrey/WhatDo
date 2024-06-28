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
    new Date { Id = Guid.NewGuid(), Name = "rock climbing", Description = null, Duration = 4, Price = null, Rating = null, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "indoor rock climbing", Description = null, Duration = 2.5, Price = null, Rating = null, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "amusement park", Description = null, Duration = 5, Price = null, Rating = null, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "bowling", Description = null, Duration = 2, Price = null, Rating = null, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "mini golf", Description = null, Duration = 2, Price = null, Rating = null, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Both },
    new Date { Id = Guid.NewGuid(), Name = "golf", Description = null, Duration = 4, Price = null, Rating = null, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "driving range", Description = null, Duration = 2, Price = null, Rating = null, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "trampoline park", Description = null, Duration = 2, Price = null, Rating = null, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "live music", Description = null, Duration = 3.5, Price = null, Rating = null, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Both },
    new Date { Id = Guid.NewGuid(), Name = "zoo", Description = null, Duration = 3.5, Price = null, Rating = null, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "botanical garden", Description = null, Duration = 2.5, Price = null, Rating = null, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Both },
    new Date { Id = Guid.NewGuid(), Name = "museum", Description = null, Duration = 3, Price = null, Rating = null, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "art museum", Description = null, Duration = 2.5, Price = null, Rating = null, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "mall", Description = null, Duration = 2, Price = null, Rating = null, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "laser tag", Description = null, Duration = 1.5, Price = null, Rating = null, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "indoor scuba diving", Description = null, Duration = 2.5, Price = null, Rating = null, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "indoor skydiving", Description = null, Duration = 1.5, Price = null, Rating = null, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "ice castle", Description = null, Duration = 2, Price = null, Rating = null, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "play/musical", Description = null, Duration = 3, Price = null, Rating = null, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "beach", Description = null, Duration = 4, Price = null, Rating = null, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "butterfly", Description = null, Duration = 2, Price = null, Rating = null, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "farmers market", Description = null, Duration = 1.5, Price = null, Rating = null, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "movie", Description = null, Duration = 3.5, Price = null, Rating = null, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "drive in movie", Description = null, Duration = 3.5, Price = null, Rating = null, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "arcade", Description = null, Duration = 1.5, Price = null, Rating = null, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "ice skating", Description = null, Duration = 1.5, Price = null, Rating = null, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Both },
    new Date { Id = Guid.NewGuid(), Name = "mountain biking", Description = null, Duration = 3, Price = null, Rating = null, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "axe throwing", Description = null, Duration = 1.5, Price = null, Rating = null, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "archery", Description = null, Duration = 1.5, Price = null, Rating = null, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Both },
    new Date { Id = Guid.NewGuid(), Name = "boba", Description = null, Duration = 1, Price = null, Rating = null, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "ice cream", Description = null, Duration = 1, Price = null, Rating = null, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "park", Description = null, Duration = 1.5, Price = null, Rating = null, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "christmas lights/lights", Description = null, Duration = 1.5, Price = null, Rating = null, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "pickle ball", Description = null, Duration = 1.5, Price = null, Rating = null, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Both },
    new Date { Id = Guid.NewGuid(), Name = "raquetball", Description = null, Duration = 1.5, Price = null, Rating = null, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "horseback riding", Description = null, Duration = 2.5, Price = null, Rating = null, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "jetskiing", Description = null, Duration = 2, Price = null, Rating = null, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "kayaking", Description = null, Duration = 3.5, Price = null, Rating = null, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "road trip", Description = null, Duration = 5, Price = null, Rating = null, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Both },
    new Date { Id = Guid.NewGuid(), Name = "snowboarding", Description = null, Duration = 4, Price = null, Rating = null, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "skiing", Description = null, Duration = 4, Price = null, Rating = null, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "paintballing", Description = null, Duration = 3, Price = null, Rating = null, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "skydiving", Description = null, Duration = 2.5, Price = null, Rating = null, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "concert", Description = null, Duration = 3, Price = null, Rating = null, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Both },
    new Date { Id = Guid.NewGuid(), Name = "air show", Description = null, Duration = 5, Price = null, Rating = null, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "ballet", Description = null, Duration = 2.5, Price = null, Rating = null, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "symphony", Description = null, Duration = 2.5, Price = null, Rating = null, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "hiking", Description = null, Duration = 3.5, Price = null, Rating = null, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
};

            modelBuilder.Entity<Date>().HasData(dates);
        }
    }
}
