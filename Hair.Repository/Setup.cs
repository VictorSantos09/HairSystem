using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Hair.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Hair.Repository
{
    public static class Setup
    {
        public static void InjectRepository(IServiceCollection services)
        {
            services.AddTransient<IBaseRepository<UserEntity>,UserRepository>();
            services.AddTransient<IBaseRepository<BarberEntity>,BarberRepository>();
        }
    }
}