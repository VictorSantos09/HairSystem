using FluentValidation;
using Hair.Application.ApiRequest;
using Hair.Application.ExceptionHandlling;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Hair.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Hair.Application
{
    /// <summary>
    /// Define as configurações do sistema
    /// </summary>
    public class Setup
    {
        /// <summary>
        /// Injeta os itns necessarios no <paramref name="services"/> fornecido
        /// </summary>
        /// <param name="services"></param>
        public static void Inject(IServiceCollection services)
        {
            services.AddTransient<IException, ExceptionHelper>();
            services.AddTransient<IApiRequest, ApiCallRequest>();
            InjectRepositories(services);
            InjectValidators(services);
        }

        private static void InjectValidators(IServiceCollection services)
        {
            services.AddTransient<IValidator<AddressEntity>, AddressValidator>();
            services.AddTransient<IValidator<UserEntity>, UserValidator>();
            services.AddTransient<IValidator<HaircutPriceEntity>, HaircutPriceValidator>();
            services.AddTransient<IValidator<BarberEntity>, BarberValidator>();
            services.AddTransient<IValidator<ClientEntity>, ClientValidator>();
            services.AddTransient<IValidator<HaircutPriceEntity>, HaircutPriceValidator>();
            services.AddTransient<IValidator<HaircutEntity>, HaircutValidator>();
            services.AddTransient<IValidator<ImageEntity>, ImageValidator>();
            services.AddTransient<IValidator<SaloonItemEntity>, SaloonItemValidator>();
        }

        private static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IGetByEmail, UserRepository>();
            services.AddTransient<IBaseRepository<UserEntity>, UserRepository>();
            services.AddTransient<IBaseRepository<HaircutEntity>, HaircutRepository>();
            services.AddTransient<IBaseRepository<BarberEntity>, BarberRepository>();
            services.AddTransient<IBaseRepository<SaloonItemEntity>, StorageRepository>();
            services.AddTransient<IBaseRepository<ImageEntity>, ImageRepository>();
        }
    }
}