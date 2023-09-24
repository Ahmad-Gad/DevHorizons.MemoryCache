namespace DevHorizons.MemoryCache.WebApiTest.Configuration
{
    using Interfaces;
    using Microsoft.OpenApi.Models;
    using System.Reflection;

    public static class ExtensionMethods
    {
        public static IApplicationConfiguration GetApplicationConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
            var applicationConfiguration = new ApplicationConfiguration
            {
                HostEnvironment = builder.Environment
            };

            builder.Configuration.Bind(applicationConfiguration);
            builder.Services.AddSingleton<IApplicationConfiguration>(applicationConfiguration);
            return applicationConfiguration;
        }

        #region Swagger
        public static void ConfigureSwagger(this IServiceCollection services, IApplicationConfiguration appConfig)
        {
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                var appVersion = Convert.ToInt32(double.Parse(appConfig.AppVersion));
                c.SwaggerDoc($"v{appVersion}", new OpenApiInfo
                {
                    Title = $"{appConfig.HostEnvironment.ApplicationName} (env. {appConfig.HostEnvironment.EnvironmentName})",
                    Version = appConfig.AppVersion
                });

                var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                var docFileName = Path.Combine(AppContext.BaseDirectory, $"{assemblyName}.xml");
                if (File.Exists(docFileName))
                {
                    c.IncludeXmlComments(docFileName);
                }

                c.DescribeAllParametersInCamelCase();
            });

            services.AddSwaggerGenNewtonsoftSupport();
        }   
        #endregion Swagger
    }
}
