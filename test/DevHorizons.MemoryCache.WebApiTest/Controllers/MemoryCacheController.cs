using Microsoft.AspNetCore.Mvc;

namespace DevHorizons.MemoryCache.WebApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemoryCacheController : ControllerBase
    {
        #region Private Fields
        private readonly ILogger<MemoryCacheController> logger;

        private readonly ICacheStore<object> cacheStore;
        #endregion Private Fields

        public MemoryCacheController(ILogger<MemoryCacheController> logger, ICacheStore<object> cacheStore)
        {
            this.logger = logger;
            this.cacheStore = cacheStore;
        }

        /// <summary>
        ///    Get value from the cache.
        /// </summary>
        /// <param name="key">The unique reference key of the cached item.</param>
        /// <returns>
        ///    The cached value.
        /// </returns>
        /// <exception cref="MemoryCacheException">Exception will be raised if the key doesn't not exist in the cache store.</exception>
        [HttpGet("Name=Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResult<object>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ActionResult<object>))]
        public async Task<ActionResult<object>> Get([FromQuery] string key)
        {
            try
            {
                var result = this.cacheStore.Get(key);
                if (result is null)
                {
                    return new ObjectResult($"The key '{key}' does not exist in the cache store!")
                    {
                        StatusCode = StatusCodes.Status404NotFound
                    };
                }

                return await Task.Run(() => this.Ok(result));
            }
            catch (MemoryCacheException ex)
            {
                return new ObjectResult(new {ex.ErrorCode, ex.Message})
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
           
        }

        /// <summary>
        ///    Add item to the cache store with the specified unique reference key and the specified value.
        /// </summary>
        /// <param name="key">The unique reference key</param>
        /// <param name="value">The value.</param>
        [HttpPost(Name = "Set")]
        public async void Set([FromQuery] string key, [FromBody] object value)
        {
            await this.cacheStore.Set(key, value);
        }

        /// <summary>
        ///    Clear the whole cache store.
        /// </summary>
        [HttpDelete(Name = "Clear")]
        public async void Clear()
        {
            await Task.Run(() => this.cacheStore.Clear());
        }
    }
}