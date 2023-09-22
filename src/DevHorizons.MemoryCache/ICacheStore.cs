// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICacheStore.cs" company="DevHorizons">
//   Copyright (c) DevHorizons. All rights reserved.
// </copyright>
// <summary>
//     Defines all the possible Cache Engine members.
// </summary>
// <Created>
//     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
//     <DateTime>22/09/2023 03:00 PM</DateTime>
// </Created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.MemoryCache
{
    /// <summary>
    ///    The cache engine which operates the internal memory cache store.
    /// </summary>
    /// <typeparam name="T">The type of the cached value.</typeparam>
    /// <Created>
    ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///     <DateTime>22/09/2023 03:00 PM</DateTime>
    /// </Created>
    public interface ICacheStore<T>
    {
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
        T Get(string key);

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
        Task Set(string key, T value);

        /// <summary>
        ///     Clear/remove all the cached item.
        /// </summary>
        void Clear();
    }
}
