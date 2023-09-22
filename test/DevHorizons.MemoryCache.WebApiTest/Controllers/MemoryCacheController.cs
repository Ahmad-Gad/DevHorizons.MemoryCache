using Microsoft.AspNetCore.Mvc;

namespace DevHorizons.MemoryCache.WebApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemoryCacheController : ControllerBase
    {
     

        private readonly ILogger<MemoryCacheController> logger;

        private readonly ICacheStore<object> cacheStore;

        public MemoryCacheController(ILogger<MemoryCacheController> logger, ICacheStore<object> cacheStore)
        {
            this.logger = logger;
            this.cacheStore = cacheStore;
        }

        [HttpGet("Name=Get")]
        public async Task<ActionResult<object>> Get([FromQuery]string key)
        {
            return await Task.Run(() => this.cacheStore.Get(key)); 
        }

        [HttpPost(Name ="Set")]
        public async void Set([FromQuery] string key, [FromBody]object value)
        {
            await this.cacheStore.Set(key, value);
        }
    }
}