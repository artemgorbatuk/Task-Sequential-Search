using Datasource.Interfaces;
using Repositories.Api;
using Services.Api;
using Services.Interfaces;

namespace Api.Middleware
{
    public static class ServiceRegistration
    {
        public static void UseDepencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryAuthentication, RepositoryAuthentication>();
            services.AddTransient<IRepositoryTextSource, RepoitoryTextSource>();

            services.AddTransient<IServiceAuthentification, ServiceAuthentification>();
            services.AddTransient<IServiceTextSource, ServiceTextSource>();
        }
    }
}