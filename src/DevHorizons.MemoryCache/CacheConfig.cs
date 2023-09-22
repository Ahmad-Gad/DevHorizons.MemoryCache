// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CacheConfig.cs" company="DevHorizons">
//   Copyright (c) DevHorizons. All rights reserved.
// </copyright>
// <summary>
//     Defines all the possible Cache Configuration members.
// </summary>
// <Created>
//     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
//     <DateTime>22/09/2023 03:00 PM</DateTime>
// </Created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.MemoryCache
{
    /// <summary>
    ///   The cache engine's configuration.
    /// </summary>
    /// <Created>
    ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///     <DateTime>22/09/2023 03:00 PM</DateTime>
    /// </Created>
    public class CacheConfig
    {
        /// <summary>
        ///    Gets or sets the maximum items to be cached.
        ///    <para>Any new items will override the least recently used cached item in the store.</para>
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>22/09/2023 03:00 PM</DateTime>
        /// </Created>
        public int Threshold { get; set; } = int.MaxValue;

        /// <summary>
        ///    Gets or sets a value indicating whether the engine will throw exception when something goes wrong with getting or settings the cache.
        ///    <para>If set to 'true' and the 'Get' operation should fail, it will return the default value of the specified type instead of throwing exception.</para>
        ///    <para>Default Value: <c>false</c>.</para>
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>22/09/2023 03:00 PM</DateTime>
        /// </Created>
        public bool SupressExceptions { get; set; }

        /// <summary>
        ///    Gets or sets a value indicating whether ignoring the case of the reference cache keys.
        ///    <para>If set to true, the engine will ignore the cache key case when getting the value.</para>
        ///    <para>Default Value: <c>false</c>.</para>
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>22/09/2023 03:00 PM</DateTime>
        /// </Created>
        public bool IgnoreCase { get; set; }
    }
}
