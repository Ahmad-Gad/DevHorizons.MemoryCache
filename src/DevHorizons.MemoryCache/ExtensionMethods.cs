// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ExtensionMethods.cs" company="DevHorizons">
//    Copyright (c) DevHorizons. All rights reserved.
//  </copyright>
//  <summary>
//    Defines the extension methods which can be consumed by the consumer libraries, APIs or applications to wrap around the library with a smoother and quicker way.
//  </summary>
//  <Created>
//    <Author>Ahmad Gad (ahmad.gad@DevHorizons.com)</Author>
//    <DateTime>01/02/2022 09:45 PM</DateTime>
//  </Created>
// --------------------------------------------------------------------------------------------------------------------
namespace DevHorizons.MemoryCache
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    ///    A public static class which holds all the extension methods which can be consumed by the consumer libraries, APIs or applications to wrap around the library with a smoother and quicker way.
    /// </summary>
    /// <Created>
    ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
    ///     <DateTime>22/09/2023 03:00 PM</DateTime>
    /// </Created>
    public static class ExtensionMethods
    {
        /// <summary>
        ///    Register the <c>DevHorizons</c> memory cache engine into the dependency injection <c>(DI)</c> container with the singlton life cycle.
        /// </summary>
        /// <param name="services">The contract for a collection of service descriptors.</param>
        /// <typeparam name="T">The type of the cached data/values.</typeparam>
        /// <exception cref="ArgumentNullException">Raise null exception if the <c>services</c> object is null.</exception>
        /// <returns>The contract for a collection of service descriptors which is used in the WebApis DI.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>22/09/2023 03:00 PM</DateTime>
        /// </Created>
        public static IServiceCollection RegisterMemoryCache<T>(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services), $"The '{nameof(RegisterMemoryCache)}' failed because it doesn't expect null argument.");
            }

            services.AddSingleton<ICacheStore<T>, CacheStore<T>>();
            return services;
        }

        /// <summary>
        ///    Register the <c>DevHorizons</c> memory cache engine into the dependency injection <c>(DI)</c> container with the singlton life cycle.
        /// </summary>
        /// <param name="services">The contract for a collection of service descriptors.</param>
        /// <param name="cacheConfig">The cache engine configuration.</param>
        /// <typeparam name="T">The type of the cached data/values.</typeparam>
        /// <exception cref="ArgumentNullException">Raise null exception if the <c>services</c> object is null.</exception>
        /// <returns>The contract for a collection of service descriptors which is used in the WebApis DI.</returns>
        /// <Created>
        ///     <Author>Ahmad Gad (ahmad.gad@devhorizons.com)</Author>
        ///     <DateTime>22/09/2023 03:00 PM</DateTime>
        /// </Created>
        public static IServiceCollection RegisterMemoryCache<T>(this IServiceCollection services, CacheConfig cacheConfig)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services), $"The '{nameof(RegisterMemoryCache)}' failed because it doesn't expect null argument.");
            }

            services.AddSingleton<ICacheStore<T>>(x => ActivatorUtilities.CreateInstance<CacheStore<T>>(x, cacheConfig));
            return services;
        }
    }
}
