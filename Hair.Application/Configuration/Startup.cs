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
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IException, ExceptionHelper>();
            services.AddTransient<IApiRequest, ApiHelper>();
            ConfigureRepositories(services);
            ConfigueValidators(services);
        }

        private static void ConfigueValidators(IServiceCollection services)
        {
            services.AddTransient<IValidator<AddressEntity>, AddressValidator>();
            services.AddTransient<IValidator<ClientEntity>, ClientValidator>();
            services.AddTransient<IValidator<ServiceOrderEntity>, DutyValidator>();
            services.AddTransient<IValidator<FunctionTypeEntity>, FunctionTypeValidator>();
            services.AddTransient<IValidator<ImageEntity>, ImageValidator>();
            services.AddTransient<IValidator<ProductEntity>, ItemValidator>();
            services.AddTransient<IValidator<ProductTypeEntity>, ItemTypeValidator>();
            services.AddTransient<IValidator<UserServiceEntity>, TaskValidator>();
            services.AddTransient<IValidator<UserServiceTypeEntity>, TaskTypeValidator>();
            services.AddTransient<IValidator<UserEntity>, UserValidator>();
            services.AddTransient<IValidator<EmployeeEntity>, WorkerValidator>();
        }

        private static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddTransient<IGetByEmail, UserRepository>();
            services.AddTransient<IServiceTypeRequest, ServiceTypeRepository>();
            services.AddTransient<IFunctionTypeRequest, FunctionTypeRepository>();
            services.AddTransient<IBaseRepository<EmployeeEntity>, WorkerRepository>();
            services.AddTransient<IBaseRepository<ProductEntity>, StorageRepository>();
            services.AddTransient<IBaseRepository<ImageEntity>, ImageRepository>();
            services.AddTransient<IBaseRepository<ServiceOrderEntity>, DutyRepository>();
            services.AddTransient<IBaseRepository<UserEntity>, UserRepository>();
        }
    }
}