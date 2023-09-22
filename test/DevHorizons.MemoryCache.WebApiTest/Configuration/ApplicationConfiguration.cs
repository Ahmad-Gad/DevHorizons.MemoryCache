

namespace DevHorizons.MemoryCache.WebApiTest.Configuration
{
    using Interfaces;

    public class ApplicationConfiguration : IApplicationConfiguration
    {
        public CacheConfig CacheConfig { get; set; }
    }
}
