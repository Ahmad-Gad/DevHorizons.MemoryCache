namespace DevHorizons.MemoryCache.WebApiTest.Configuration
{
    using Interfaces;
    public static class ExtensionMethods
    {
        public static IApplicationConfiguration GetApplicationConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
            var applicationConfiguration = new ApplicationConfiguration();
            builder.Configuration.Bind(applicationConfiguration);
            builder.Services.AddSingleton<IApplicationConfiguration>(applicationConfiguration);
            return applicationConfiguration;
        }
    }
}
