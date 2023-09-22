namespace DevHorizons.MemoryCache.UnitTest
{

    public class UnitTestIgnoreCase
    {

        private CacheStore<object> cacheStore;

        public UnitTestIgnoreCase()
        {
            var config = new CacheConfig
            {
                IgnoreCase = true,
                Threshold = 3
            };

            this.cacheStore = new CacheStore<object>(config);
        }

        [Fact]
        public async void Test()
        {
            await this.cacheStore.Set("Name", "Ahmad");
            var name  = this.cacheStore.Get("NAME");
            var name2 = this.cacheStore.Get("name");
            var expected = "Ahmad";
            Assert.True(name.Equals(name2));
            Assert.Equal(expected, name);

            await this.cacheStore.Set("NAME", "Gad");
            name = this.cacheStore.Get("NAME");
            name2 = this.cacheStore.Get("name");
            expected = "Gad";
            Assert.True(name.Equals(name2));
            Assert.Equal(expected, name);

            await this.cacheStore.Set("NAME2", "name2");
            var actual = this.cacheStore.Get("NAME2");
            expected = "name2";
            Assert.Equal(expected, actual);

            await this.cacheStore.Set("NAME3", "name3");
            actual = this.cacheStore.Get("NAME3");
            expected = "name3";
            Assert.Equal(expected, actual);

            actual = this.cacheStore.Get("NAME");
            expected = "Gad";
            Assert.Equal(expected, actual);

            await this.cacheStore.Set("NAME4", "name4");
            actual = this.cacheStore.Get("NAME4");
            expected = "name4";
            Assert.Equal(expected, actual);

            var ex = Record.Exception(() => this.cacheStore.Get("NAME2"));
            Assert.NotNull(ex);
            Assert.IsType<MemoryCacheException>(ex);
        }
    }
}