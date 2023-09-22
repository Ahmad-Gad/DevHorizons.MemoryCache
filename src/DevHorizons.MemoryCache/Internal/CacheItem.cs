// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CacheItem.cs" company="DevHorizons">
//   Copyright (c) DevHorizons. All rights reserved.
// </copyright>
// <summary>
//     Defines all the possible Cache Item members.
// </summary>
// <Created>
//     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
//     <DateTime>22/09/2023 03:00 PM</DateTime>
// </Created>
// --------------------------------------------------------------------------------------------------------------------

namespace DevHorizons.MemoryCache.Internal
{
    /// <summary>
    ///     The cache item type.
    /// </summary>
    /// <typeparam name="T">The type of the cached value.</typeparam>
    /// <Created>
    ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///     <DateTime>22/09/2023 03:00 PM</DateTime>
    /// </Created>
    internal class CacheItem<T>
    {
        #region Constructors

        /// <summary>
        ///    Initializes a new instance of the <see cref="CacheItem{T}"/> class.
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>22/09/2023 03:00 PM</DateTime>
        /// </Created>
        internal CacheItem()
        {
        }

        /// <summary>
        ///    Initializes a new instance of the <see cref="CacheItem{T}"/> class.
        /// </summary>
        /// <param name="timeStamp">The timestamp of the cache insertion or usage.</param>
        /// <param name="value">The value to be cached.</param>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>22/09/2023 03:00 PM</DateTime>
        /// </Created>
        internal CacheItem(DateTime timeStamp, T value)
        {
            this.TimeStamp = timeStamp;
            this.Value = value;
        }
        #endregion Constructors

        #region Properties

        /// <summary>
        ///    Gets or sets the dynamic timestamp of the cached item which is being set when the cached item is being set the first time and being updated each time getting the cached item.
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>22/09/2023 03:00 PM</DateTime>
        /// </Created>
        internal DateTime TimeStamp { get; set; }

        /// <summary>
        ///    Gets or sets the cached value.
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>22/09/2023 03:00 PM</DateTime>
        /// </Created>
        internal T Value { get; set; }
        #endregion Properties
    }
}