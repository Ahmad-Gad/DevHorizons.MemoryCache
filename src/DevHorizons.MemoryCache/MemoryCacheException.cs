// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MemoryCacheException.cs" company="DevHorizons">
//   Copyright (c) DevHorizons. All rights reserved.
// </copyright>
// <summary>
//     Internal custom Exception implementation of the cache engine.
// </summary>
// <Created>
//     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
//     <DateTime>22/09/2023 03:00 PM</DateTime>
// </Created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.MemoryCache
{
    /// <summary>
    ///    The exception that is thrown when the cache engine's operation encounter an error or violation.
    /// </summary>
    /// <Created>
    ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///     <DateTime>22/09/2023 03:00 PM</DateTime>
    /// </Created>
    public class MemoryCacheException : Exception
    {
        /// <summary>
        ///    Initializes a new instance of the <see cref="MemoryCacheException"/> class.
        /// </summary>
        /// <param name="errorCode">The raised error code.</param>
        /// <param name="message">The raised error message.</param>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>22/09/2023 03:00 PM</DateTime>
        /// </Created>
        public MemoryCacheException(int errorCode, string message)
            : base(message)
        {
            this.ErrorCode = errorCode;
        }

        /// <summary>
        ///    Gets the raised error code.
        /// </summary>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>22/09/2023 03:00 PM</DateTime>
        /// </Created>
        public int ErrorCode { get; }
    }
}
