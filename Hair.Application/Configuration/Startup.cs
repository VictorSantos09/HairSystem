using FluentValidation;
using Hair.Application.ApiRequest;
using Hair.Application.ExceptionHandlling;
using Hair.Application.Factories;
using Hair.Application.Factories.Interfaces;
using Hair.Application.Interfaces.UserCases;
using Hair.Application.Services.UserCases.EmployeeManagment;
using Hair.Application.Services.UserCases.UserAccountManagment;
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
            collection.AddTransient<IGetByEmailDbContext, UserRepository>();
            collection.AddTransient<IServiceTypeRequestDbContext, ServiceTypeRepository>();
            collection.AddTransient<IFunctionTypeRequestDbContext, FunctionTypeRepository>();
            collection.AddTransient<IApplicationDbContext<EmployeeEntity>, EmployeeRepository>();
            collection.AddTransient<IApplicationDbContext<ProductEntity>, ProductRepository>();
            collection.AddTransient<IApplicationDbContext<ImageEntity>, ImageRepository>();
            collection.AddTransient<IApplicationDbContext<ServiceOrderEntity>, ServiceOrderRepository>();
            collection.AddTransient<IApplicationDbContext<UserEntity>, UserRepository>();
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
    }
}