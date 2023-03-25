using FluentValidation;
using Hair.Application.ApiRequest;
using Hair.Application.ExceptionHandler;
using Hair.Application.Factories;
using Hair.Application.Factories.Interfaces;
using Hair.Application.Interfaces.UserCases;
using Hair.Application.Services.UserCases.EmployeeManagment;
using Hair.Application.Services.UserCases.UserAccountManagment;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces.Repositories;
using Hair.Repository.Interfaces.Security;
using Hair.Repository.Repositories;
using Hair.Repository.Security;
using Microsoft.Extensions.DependencyInjection;

namespace Hair.Application.Configuration
{
    /// <summary>
    /// Define as configurações do sistema.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configura as dependências do projeto.
        /// </summary>
        /// <param name="collection">Coleção para inserir as dependências.</param>
        public static void Configure(IServiceCollection collection)
        {
            collection.AddTransient<IException, ExceptionHelper>();
            collection.AddTransient<IApiRequest, ApiHelper>();
            ConfigureRepositories(collection);
            ConfigueValidators(collection);
            ConfigureServices(collection);
            ConfigureFactory(collection);
            ConfigureSecurity(collection);
        }

        private static void ConfigueValidators(IServiceCollection collection)
        {
            collection.AddTransient<IValidator<AddressEntity>, AddressValidator>();
            collection.AddTransient<IValidator<ClientEntity>, ClientValidator>();
            collection.AddTransient<IValidator<ServiceOrderEntity>, ServiceOrderValidator>();
            collection.AddTransient<IValidator<FunctionTypeEntity>, FunctionTypeValidator>();
            collection.AddTransient<IValidator<ImageEntity>, ImageValidator>();
            collection.AddTransient<IValidator<ProductEntity>, ProductValidator>();
            collection.AddTransient<IValidator<ProductTypeEntity>, ProductTypeValidator>();
            collection.AddTransient<IValidator<UserServiceEntity>, UserServiceValidator>();
            collection.AddTransient<IValidator<UserServiceTypeEntity>, UserServiceTypeValidator>();
            collection.AddTransient<IValidator<UserEntity>, UserValidator>();
            collection.AddTransient<IValidator<EmployeeEntity>, EmployeeValidator>();
        }

        private static void ConfigureRepositories(IServiceCollection collection)
        {
            collection.AddTransient<IEmployeeRepository, EmployeeRepository>();
            collection.AddTransient<IFunctionTypeRepository, FunctionTypeRepository>();
            collection.AddTransient<IImageRepository, ImageRepository>();
            collection.AddTransient<IProductRepository, ProductRepository>();
            collection.AddTransient<IServiceOrderRepository,ServiceOrderRepository>();
            collection.AddTransient<IServiceTypeRepository, ServiceTypeRepository>();
            collection.AddTransient<IUserRepository, UserRepository>();

        }

        private static void ConfigureServices(IServiceCollection colletion)
        {
            ConfigureManagmentEmployee(colletion);
            ConfigureUserAccountManagment(colletion);
        }

        private static void ConfigureManagmentEmployee(IServiceCollection colletion)
        {
            colletion.AddTransient<IDeleteEmployee, DeleteEmployeeService>();
            colletion.AddTransient<IUpdateEmployee, UpdateEmployeeService>();
            colletion.AddTransient<ICreateEmployee, CreateEmployeeService>();
            colletion.AddTransient<IViewEmployeeData, ViewEmployeeDataService>();
            colletion.AddTransient<IEmployeeManagment, EmployeeManagmentService>();
        }

        private static void ConfigureUserAccountManagment(IServiceCollection colletion)
        {
            colletion.AddTransient<IDeleteAccount, DeleteAccountService>();
            colletion.AddTransient<ILogin, LoginService>();
            colletion.AddTransient<IRegister, RegisterService>();
        }

        private static void ConfigureFactory(IServiceCollection colletion)
        {
            colletion.AddTransient<IFactory, Factory>();
        }

        private static void ConfigureSecurity(IServiceCollection colletion)
        {
            colletion.AddTransient<ICryptoSecurity, CryptoSecurity>();
            colletion.AddTransient<IKeyManagment, KeyManagment>();
        }
    }
}