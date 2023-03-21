using FluentValidation;
using Hair.Application.ApiRequest;
using Hair.Application.ExceptionHandlling;
using Hair.Application.Interfaces;
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
        }

        private static void ConfigueValidators(IServiceCollection collection)
        {
            collection.AddTransient<IValidator<AddressEntity>, AddressValidator>();
            collection.AddTransient<IValidator<ClientEntity>, ClientValidator>();
            collection.AddTransient<IValidator<ServiceOrderEntity>, DutyValidator>();
            collection.AddTransient<IValidator<FunctionTypeEntity>, FunctionTypeValidator>();
            collection.AddTransient<IValidator<ImageEntity>, ImageValidator>();
            collection.AddTransient<IValidator<ProductEntity>, ItemValidator>();
            collection.AddTransient<IValidator<ProductTypeEntity>, ItemTypeValidator>();
            collection.AddTransient<IValidator<UserServiceEntity>, TaskValidator>();
            collection.AddTransient<IValidator<UserServiceTypeEntity>, TaskTypeValidator>();
            collection.AddTransient<IValidator<UserEntity>, UserValidator>();
            collection.AddTransient<IValidator<EmployeeEntity>, WorkerValidator>();
        }

        private static void ConfigureRepositories(IServiceCollection collection)
        {
            collection.AddTransient<IGetByEmail, UserRepository>();
            collection.AddTransient<IServiceTypeRequest, ServiceTypeRepository>();
            collection.AddTransient<IFunctionTypeRequest, FunctionTypeRepository>();
            collection.AddTransient<IBaseRepository<EmployeeEntity>, EmployeeRepository>();
            collection.AddTransient<IBaseRepository<ProductEntity>, ProductRepository>();
            collection.AddTransient<IBaseRepository<ImageEntity>, ImageRepository>();
            collection.AddTransient<IBaseRepository<ServiceOrderEntity>, ServiceOrderRepository>();
            collection.AddTransient<IBaseRepository<UserEntity>, UserRepository>();
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
    }
}