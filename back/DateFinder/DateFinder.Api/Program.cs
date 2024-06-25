using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DateFinder.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder().Build().Run();
        }

        public static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}


//using Microsoft.EntityFrameworkCore;
//using DateFinder.Storage;


//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllers();

//// Add DbContext
//builder.Services.AddDbContext<DateFinderDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DateFinderConnectionString"));
//});

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
