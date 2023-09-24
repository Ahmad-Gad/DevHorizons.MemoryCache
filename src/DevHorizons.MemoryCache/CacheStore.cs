// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CacheStore.cs" company="DevHorizons">
//   Copyright (c) DevHorizons. All rights reserved.
// </copyright>
// <summary>
//     Defines all the possible Cache Store members.
// </summary>
// <Created>
//     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
//     <DateTime>22/09/2023 03:00 PM</DateTime>
// </Created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.MemoryCache
{
    using System.Collections.Generic;

    using Internal;

    /// <summary>
    ///    The cache store which holds the public memory cache stores and all the operations against them.
    /// </summary>
    /// <typeparam name="T">The type of the cached value.</typeparam>
    /// <Created>
    ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///     <DateTime>22/09/2023 03:00 PM</DateTime>
    /// </Created>
    public class CacheStore<T> : ICacheStore<T>
    {
        #region Private Fields

        /// <summary>
        ///    The cached data/values in a list sorted automatically by the key.
        /// </summary>
        private SortedList<string, CacheItem<T>> cachedData = new SortedList<string, CacheItem<T>>();

        /// <summary>
        ///   A list holds the keys of the cached data sorted automatically by the dynamic timestamp.
        /// </summary>
        private SortedDictionary<DateTime, string> indexedTimeStamp = new SortedDictionary<DateTime, string>();

        /// <summary>
        ///    The cache engine configuration.
        /// </summary>
        private CacheConfig config;
        #endregion Private Fields

        #region Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="CacheStore{T}"/> class.
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>22/09/2023 03:00 PM</DateTime>
        /// </Created>
        public CacheStore()
        {
            this.config = new CacheConfig();
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="CacheStore{T}"/> class.
        /// </summary>
        /// <param name="cacheConfig">The cache engine configuration.</param>
        public CacheStore(CacheConfig cacheConfig)
        {
            this.config = cacheConfig;
        }
        #endregion Constructors

        #region Public Methods

        /// <summary>
        ///    Gets the cached data/value by the specified unique key.
        /// </summary>
        /// <param name="key">The unique key of the cached item.</param>
        /// <returns>
        ///    The cached value/data.
        /// </returns>
        /// <exception cref="MemoryCacheException">The exception which will be raised if the key does not exist.</exception>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>22/09/2023 03:00 PM</DateTime>
        /// </Created>
        public T Get(string key)
        {
            var actualKey = this.config.IgnoreCase ? key.ToUpperInvariant() : key;
            if (this.cachedData.ContainsKey(actualKey))
            {
                var cachedItem = this.cachedData[actualKey];
                this.UpdateIndex(actualKey, cachedItem);
                return cachedItem.Value;
            }

            if (this.config.SupressExceptions)
            {
                return default;
            }

            throw new MemoryCacheException(404, $"The key '{key}' is invalid!");
        }

        /// <summary>
        ///    Add or override values into the memory cache with the reference of the specified unique key.
        /// </summary>
        /// <param name="key">The unique reference key.</param>
        /// <param name="value">The value to be cached.</param>
        /// <returns>
        ///    The task of the async set operation.
        /// </returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>22/09/2023 03:00 PM</DateTime>
        /// </Created>
        public async Task Set(string key, T value)
        {
            var actualKey = this.config.IgnoreCase ? key.ToUpperInvariant() : key;
            await Task.Run(() => this.SetDataWithLocking(actualKey, value));
        }

        /// <summary>
        ///     Clear/remove all the cached item.
        /// </summary>
        public void Clear()
        {
            lock (this.cachedData) lock (this.indexedTimeStamp)
                {
                    this.cachedData.Clear();
                    this.indexedTimeStamp.Clear();
                }
        }
        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///    Persist the data into the cache store with locking the related store objects.
        /// </summary>
        /// <param name="key">The cache key.</param>
        /// <param name="value">The cache value.</param>
        private void SetDataWithLocking(string key, T value)
        {
            lock (this.cachedData) lock (this.indexedTimeStamp)
                {
                    if (this.cachedData.ContainsKey(key))
                    {
                        this.UpdateData(key, value);
                        return;
                    }

                    if (this.cachedData.Count == this.config.Threshold)
                    {
                        var indexEnumerator = this.indexedTimeStamp.GetEnumerator();
                        indexEnumerator.MoveNext();
                        var oldKey = indexEnumerator.Current;
                        this.indexedTimeStamp.Remove(oldKey.Key);
                        this.cachedData.Remove(oldKey.Value);
                    }

                    this.SetData(key, value);
                }
        }

        /// <summary>
        ///    Persist the data into the cache store.
        /// </summary>
        /// <param name="key">The cache key.</param>
        /// <param name="value">The cache value.</param>
        private void SetData(string key, T value)
        {
            var timeStamp = DateTime.Now;
            this.cachedData.Add(key, new CacheItem<T>(timeStamp, value));
            this.indexedTimeStamp.Add(timeStamp, key);
        }

        /// <summary>
        ///    Update the value and the timestamp of the existing cached item in the store store.
        /// </summary>
        /// <param name="key">The cache key.</param>
        /// <param name="value">The cache value.</param>
        private void UpdateData(string key, T value)
        {
            var timeStamp = DateTime.Now;
            var cachedItem = this.cachedData[key];
            cachedItem.Value = value;
            this.indexedTimeStamp.Remove(cachedItem.TimeStamp);
            cachedItem.TimeStamp = timeStamp;
            this.indexedTimeStamp.Add(timeStamp, key);
        }

        /// <summary>
        ///    Update the cache timestamp index when it is being used/called by using the "<see cref="Get(string)"/>" method.
        /// </summary>
        /// <param name="key">The cache key.</param>
        /// <param name="cacheItem">The cache item.</param>
        private void UpdateIndex(string key, CacheItem<T> cacheItem)
        {
            lock (this.indexedTimeStamp)
            {
                var timeStamp = DateTime.Now;
                this.indexedTimeStamp.Remove(cacheItem.TimeStamp);
                cacheItem.TimeStamp = timeStamp;
                this.indexedTimeStamp.Add(timeStamp, key);
            }
        }
        #endregion Private Methods
    }
}
