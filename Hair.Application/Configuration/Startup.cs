using FluentValidation;
using Hair.Application.ApiRequest;
using Hair.Application.ExceptionHandlling;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Hair.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Hair.Application.Configuration
{
    /// <summary>
    /// Define as configurações do sistema
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Injeta os itns necessarios no <paramref name="services"/> fornecido
        /// </summary>
        /// <param name="services"></param>
        public static void Inject(IServiceCollection services)
        {
            services.AddTransient<IException, ExceptionHelper>();
            services.AddTransient<IApiRequest, ApiHelper>();
            InjectRepositories(services);
            InjectValidators(services);
        }

        private static void InjectValidators(IServiceCollection services)
        {
            services.AddTransient<IValidator<AddressEntity>, AddressValidator>();
            services.AddTransient<IValidator<ClientEntity>, ClientValidator>();
            services.AddTransient<IValidator<DutyEntity>, DutyValidator>();
            services.AddTransient<IValidator<FunctionTypeEntity>, FunctionTypeValidator>();
            services.AddTransient<IValidator<ImageEntity>, ImageValidator>();
            services.AddTransient<IValidator<ItemEntity>, ItemValidator>();
            services.AddTransient<IValidator<ItemTypeEntity>, ItemTypeValidator>();
            services.AddTransient<IValidator<ServiceEntity>, ServiceValidator>();
            services.AddTransient<IValidator<ServiceTypeEntity>, ServiceTypeValidator>();
            services.AddTransient<IValidator<UserEntity>, UserValidator>();
            services.AddTransient<IValidator<WorkerEntity>, WorkerValidator>();
        }

        private static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IGetByEmail, UserRepository>();
            services.AddTransient<IServiceTypeRequest, ServiceTypeRepository>();
            services.AddTransient<IFunctionTypeRequest, FunctionTypeRepository>();
            services.AddTransient<IBaseRepository<WorkerEntity>, WorkerRepository>();
            services.AddTransient<IBaseRepository<ItemEntity>, StorageRepository>();
            services.AddTransient<IBaseRepository<ImageEntity>, ImageRepository>();
            services.AddTransient<IBaseRepository<DutyEntity>, DutyRepository>();
            services.AddTransient<IBaseRepository<UserEntity>, UserRepository>();
        }
    }
}