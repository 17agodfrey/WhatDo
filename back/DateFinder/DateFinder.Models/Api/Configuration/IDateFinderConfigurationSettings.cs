namespace DateFinder.Domain.Api.Configuration
{
    public interface IDateFinderConfigurationSettings
    {
        //string AuthenticationPrivateKey { get; }
        string DateFinderConnectionString { get; }
        string FourSquareApiKey { get; }
    }
}
