using Hair.Application.Exeception;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Hair.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Hair.Application
{
    /// <summary>
    /// Define as configurações do sistema
    /// </summary>
    public static class Setup
    {
        /// <summary>
        /// Injeta os itns necessarios no <paramref name="services"/> fornecido
        /// </summary>
        /// <param name="services"></param>
        public static void Inject(IServiceCollection services)
        {
            services.AddTransient<IBaseRepository<UserEntity>, UserRepository>();
            services.AddTransient<IBaseRepository<BarberEntity>, BarberRepository>();
            services.AddTransient<IBaseRepository<SaloonItemEntity>, StorageRepository>();
            services.AddTransient<IBaseRepository<ImageEntity>, ImageRepository>();
            services.AddTransient<IBaseRepository<HaircutEntity>, HaircutRepository>();

            services.AddTransient<IGetByEmail, UserRepository>();
            services.AddTransient<IExeception, ExeceptionHelper>();
        }
    }
}