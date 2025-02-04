using DateFinder.Domain.Api.Configuration;
using Microsoft.Extensions.Configuration;

namespace DateFinder.Api.Configuration
{
    public class DateFinderConfigurationSettings: IDateFinderConfigurationSettings
    {
        //private readonly IConfigurationRoot _configurationRoot;
        private readonly IConfiguration _configuration;

        public DateFinderConfigurationSettings(IConfiguration configuration)
        {
            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .AddEnvironmentVariables(); // Add environment variables support


            //_configurationRoot = builder.Build();

            _configuration = configuration;

        }

        //public string AuthenticationPrivateKey => _configurationRoot.GetSection("AppSettings")["AuthenticationPrivateKey"];
        public string DateFinderConnectionString => _configuration.GetSection("ConnectionStrings")["DateFinderConnectionString"];
        public string GoogleMapsApiKey => _configuration.GetSection("GoogleMaps")["ApiKey"];
    }

}
