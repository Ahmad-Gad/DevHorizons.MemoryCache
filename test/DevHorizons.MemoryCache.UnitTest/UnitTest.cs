namespace DevHorizons.MemoryCache.UnitTest
{

    public class UnitTest
    {

        private CacheStore<object> cacheStore;

        public UnitTest()
        {
            var config = new CacheConfig
            {
                Threshold = 3,
                SupressExceptions = true
            };

            this.cacheStore = new CacheStore<object>(config);
        }

        [Fact]
        public async void Test()
        {
            await this.cacheStore.Set("Name", "Ahmad");
            var actual  = this.cacheStore.Get("Name");
            var expected = "Ahmad";
            Assert.Equal(expected, actual);

            var name2 = this.cacheStore.Get("NAME");
            Assert.Null(name2);

            
            await this.cacheStore.Set("NAME", "Gad");
            actual = this.cacheStore.Get("NAME");
            expected = "Gad";
            Assert.Equal(expected, actual);

            actual = this.cacheStore.Get("Name");
            expected = "Ahmad";
            Assert.Equal(expected, actual);
        }
    }
}