using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using poc_dependency_injection.Application.Interfaces;
using poc_dependency_injection.Application.Services;

namespace poc_dependency_injection.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IScopedService, ScopedService>();
            services.AddTransient<ITransientService, TransientService>();
            services.AddSingleton<ISingletonService, SingletonService>();

            return services;
        }
    }
}