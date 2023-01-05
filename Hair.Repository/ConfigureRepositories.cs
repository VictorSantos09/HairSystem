using Hair.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Hair.Repository
{
    public static class ConfigureRepositories
    {
        public static void AddRepositoriesToCollection(IServiceCollection services)
        {
            services.AddSingleton<UserRepository>();
            services.AddSingleton<StorageRepository>();
            services.AddSingleton<HaircuteRepository>();
        }
    }
}