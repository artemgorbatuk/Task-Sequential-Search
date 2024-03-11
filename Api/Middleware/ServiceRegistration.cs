using Datasource.Contexts;
using Datasource.Factories;
using Datasource.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repositories.Api;
using Services.Api;
using Services.Interfaces;

namespace Api.Middleware
{
    public static class ServiceRegistration
    {
        public static void UseDepencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryAuthentication, RepositoryAuthentication>();
            services.AddScoped<IRepositoryTextSource, RepoitoryTextSource>();

            services.AddScoped<IServiceAuthentification, ServiceAuthentification>();
            services.AddScoped<IServiceTextSource, ServiceTextSource>();
        }

        public static void UseDbContextFactory(this IServiceCollection services, string connectionString)
        {
            // ДЛЯ СОЗДАНИЯ ПОТОКОБЕЗОПАСНОГО DbContext ТРЕБУЕТСЯ:
            // 1 создать DbContextFactorySequentialSearch с жизненным циклом Singleton отнаследованного от IServiceScopeFactory
            // 2 зарегистрировать DbContext c жизненным циклом Scoped
            // 3 получение контекста в Repository будет происходить через IServiceScopeFactory (к сожалению антипаттерн)
            // 4 Repository и Service должны быть зарегистрированы как AddScoped

            services.AddSingleton<IServiceScopeFactory, DbContextFactorySequentialSearch>();

            services.AddDbContext<DbContextSequentialSearch>(options =>
            {
                if (!options.IsConfigured)
                {
                    // во время запуска тестов без этой проверки
                    // возникает ошибка 'Multiple database providers in service provider'.
                    // InMemory создает свою конфигурацию.
                    options.UseSqlServer(connectionString);
                }
            },ServiceLifetime.Scoped);
        }
    }
}