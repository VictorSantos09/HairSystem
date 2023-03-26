using FluentValidation;
using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.Extensions;
using Hair.Application.Factories.Interfaces;
using Hair.Application.Interfaces.UserCases;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces.Repositories;

namespace Hair.Application.Services.UserCases.UserServiceManagment
{
    public sealed class CreateUserServiceService : ICreateUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IServiceTypeRepository _ServiceTypeRepository;
        private readonly IUserServiceRepository _userServiceRepository;
        private readonly IValidator<UserServiceEntity> _userServiceValidator;
        private readonly IFactory _factory;

        public CreateUserServiceService(IUserRepository userRepository, IServiceTypeRepository serviceTypeRepository,
            IUserServiceRepository userServiceRepository, IValidator<UserServiceEntity> userServiceValidator, IFactory factory)
        {
            _userRepository = userRepository;
            _ServiceTypeRepository = serviceTypeRepository;
            _userServiceRepository = userServiceRepository;
            _userServiceValidator = userServiceValidator;
            _factory = factory;
        }

        public BaseDto Create(CreateUserServiceDto dto)
        {
            var user = _userRepository.GetById(dto.UserID);

            if (user == null)
                return BaseDtoExtension.NotFound();

            var userServices = _userServiceRepository.GetAllByUserId(dto.UserID);

            if (userServices.Exists(x => x.Name == dto.Name && x.Type.Name == dto.ServiceType))
                return BaseDtoExtension.Invalid("Não é possível criar serviços com nome e tipo iguais.");

            UserServiceEntity service = _userServiceRepository.GetByName(dto.Name);

            if (service == null)
                return BaseDtoExtension.Invalid("Serviço não existente.");

            UserServiceTypeEntity serviceType = _ServiceTypeRepository.GetByName(dto.ServiceType);

            if (serviceType == null)
                return BaseDtoExtension.Invalid("Tipo de tarefa inválido.");

            UserServiceEntity newService = _factory.UserService.Create(user.Id, dto.Name, dto.Value, dto.Description, serviceType);

            ValidationResultDto result = Validation.Verify(_userServiceValidator.Validate(newService));

            if (result.Condition)
            {
                _userServiceRepository.Create(newService);
                return BaseDtoExtension.Sucess();
            }

            return Validation.ToBaseDto(result);
        }
    }
}