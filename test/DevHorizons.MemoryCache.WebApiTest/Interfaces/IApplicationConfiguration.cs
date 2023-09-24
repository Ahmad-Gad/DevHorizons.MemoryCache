namespace DevHorizons.MemoryCache.WebApiTest.Interfaces
{
    public interface IApplicationConfiguration
    {
        string AppName { get; set; }

        string AppVersion { get; set; }

        IWebHostEnvironment HostEnvironment { get; set; }

        CacheConfig CacheConfig { get; set; }
    }
}
