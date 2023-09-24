namespace DevHorizons.MemoryCache.WebApiTest.Configuration
{
    using Interfaces;

    public class ApplicationConfiguration : IApplicationConfiguration
    {
        public CacheConfig CacheConfig { get; set; }

        public string AppVersion { get; set; }

        public string AppName { get; set; }

        public IWebHostEnvironment HostEnvironment { get; set; }
    }
}
