using Hair.Application.Interfaces;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Hair.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Hair.Application
{
    public static class Setup
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddTransient<IBaseRepository<UserEntity>, UserRepository>();
            services.AddTransient<IBaseRepository<BarberEntity>, BarberRepository>();
            services.AddTransient<IBaseRepository<SaloonItemEntity>, StorageRepository>();
            services.AddTransient<IBaseRepository<ImageEntity>, ImageRepository>();
            services.AddTransient<IBaseRepository<HaircutEntity>, HaircutRepository>();

            services.AddTransient<IGetByEmail, UserRepository>();

            InjectServices(services);
        }

        private static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IChangePrice, ChangePriceService>();
            services.AddTransient<IManagmentWorker, ManagmentWorkerService>();
        }
    }
}