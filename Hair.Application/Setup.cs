using Hair.Application.Exeception;
using Hair.Domain.Entities;
using Hair.Domain.Interfaces;
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
            services.AddTransient<IUser, UserEntity>();
            services.AddTransient<IHaircut, HaircutEntity>();
            services.AddTransient<IHaircutPrice, HaircutPriceEntity>();
            services.AddTransient<IAddress, AddressEntity>();
            services.AddTransient<IImage, ImageEntity>();


            services.AddTransient<IBaseRepository<IUser>, UserRepository>();
            services.AddTransient<IBaseRepository<IHaircut>, HaircutRepository>();
            services.AddTransient<IBaseRepository<IBarber>, BarberRepository>();
            services.AddTransient<IBaseRepository<ISaloonItem>, StorageRepository>();
            services.AddTransient<IBaseRepository<IImage>, ImageRepository>();

            services.AddTransient<IGetByEmail, UserRepository>();
            services.AddTransient<IExeception, ExeceptionHelper>();
        }
    }
}