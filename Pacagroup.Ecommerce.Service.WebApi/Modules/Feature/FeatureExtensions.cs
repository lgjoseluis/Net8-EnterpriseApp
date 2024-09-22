using Pacagroup.Ecommerce.Service.WebApi.Helpers;

namespace Pacagroup.Ecommerce.Service.WebApi.Modules.Feature
{
    public static class FeatureExtensions
    {
        public static IServiceCollection AddFeatures(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("policyApiEcommerce",
                    policy =>
                    {
                        policy.WithOrigins(configuration.GetSection("Config:OriginCors").Value)
                        .AllowAnyMethod();
                    });
            });

            IConfigurationSection appSettings = configuration.GetSection("Config");
            services.Configure<AppSettings>(appSettings);

            return services;
        }
    }
}
