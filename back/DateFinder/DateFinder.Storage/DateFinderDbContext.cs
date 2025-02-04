using Microsoft.EntityFrameworkCore;
using DateFinder.Domain.Storage.EnumAttributes;
using DateFinder.Domain.Storage;


namespace DateFinder.Storage
{
    public class DateFinderDbContext : DbContext
    {
        public DbSet<Date> Dates { get; set; }
        private static int _instanceCount = 0;


        public DateFinderDbContext(DbContextOptions<DateFinderDbContext> options) : base(options)
        {
            Interlocked.Increment(ref _instanceCount);
            Console.WriteLine($"DbContext instance created. Current count: {_instanceCount}");
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

            int i = 1;

            var dates = new List<Date>
{
    new Date { Id = i++, Name = "rock climbing", Duration = 4, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "indoor rock climbing", Duration = 2.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "amusement park", Duration = 5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "bowling", Duration = 2, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "mini golf", Duration = 2, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Any },
    new Date { Id = i++, Name = "golf", Duration = 4, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "driving range", Duration = 2, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "trampoline park", Duration = 2, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "live music", Duration = 3.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Any },
    new Date { Id = i++, Name = "zoo", Duration = 3.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "botanical garden", Duration = 2.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Any },
    new Date { Id = i++, Name = "museum", Duration = 3, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "art museum", Duration = 2.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "mall", Duration = 2, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "laser tag", Duration = 1.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "indoor scuba diving", Duration = 2.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "indoor skydiving", Duration = 1.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "ice castle", Duration = 2, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "play/musical", Duration = 3, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "beach", Duration = 4, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "butterfly", Duration = 2, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "farmers market", Duration = 1.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "movie", Duration = 3.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "drive in movie", Duration = 3.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "arcade", Duration = 1.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "ice skating", Duration = 1.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Any },
    new Date { Id = i++, Name = "mountain biking", Duration = 3, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "axe throwing", Duration = 1.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "archery", Duration = 1.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Any },
    new Date { Id = i++, Name = "boba", Duration = 1, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "ice cream", Duration = 1, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "park", Duration = 1.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "christmas lights", Duration = 1.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "pickle ball", Duration = 1.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Any },
    new Date { Id = i++, Name = "raquetball", Duration = 1.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "horseback riding", Duration = 2.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "jetskiing", Duration = 2, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "kayaking", Duration = 3.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "road trip", Duration = 5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Any },
    new Date { Id = i++, Name = "skiing", Duration = 4, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "paintballing", Duration = 3, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "skydiving", Duration = 2.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "concert", Duration = 3, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Any },
    new Date { Id = i++, Name = "air show", Duration = 5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "symphony", Duration = 2.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "hiking", Duration = 3.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
};

            modelBuilder.Entity<Date>().HasData(dates);
        }


        public override void Dispose()
        {
            base.Dispose();
            Interlocked.Decrement(ref _instanceCount);
            //_logger.LogInformation($"DbContext instance disposed. Current count: {_instanceCount}");
            Console.WriteLine($"DbContext instance disposed. Current count: {_instanceCount}");
        }

        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            Interlocked.Decrement(ref _instanceCount);
            //_logger.LogInformation($"DbContext instance disposed asynchronously. Current count: {_instanceCount}");
            Console.WriteLine($"DbContext instance disposed. Current count: {_instanceCount}");
        }

        public static int GetInstanceCount()
        {
            return _instanceCount;
        }




    }
}
