namespace DateFinder.Api.Configuration
{
    public class DateFinderConfigurationSettings: IDateFinderConfigurationSettings
    {
        private readonly IConfigurationRoot _configurationRoot;

        public DateFinderConfigurationSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configurationRoot = builder.Build();
        }

        //public string AuthenticationPrivateKey => _configurationRoot.GetSection("AppSettings")["AuthenticationPrivateKey"];
        public string ResumeRocketQueryDatabaseConnectionString => _configurationRoot.GetSection("ConnectionStrings")["DateFinderConnectionString"];
    }

}
