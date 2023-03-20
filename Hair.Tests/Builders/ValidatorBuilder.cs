using FluentValidation;
using Hair.Application.Validators;
using Hair.Domain.Entities;

namespace Hair.Tests.Builders
{
    internal sealed class ValidatorBuilder
    {
        private IValidator<UserEntity> _userValidator;
        private IValidator<AddressEntity> _addressValidator;
        private IValidator<ClientEntity> _clientValidator;
        private IValidator<ServiceOrderEntity> _haircutValidator;
        private IValidator<EmployeeEntity> _workerValidator;
        private IValidator<ProductEntity> _itemValidator;
        private IValidator<ImageEntity> _imageValidator;
        public ValidatorBuilder()
        {
            _addressValidator = new AddressValidator();
            _clientValidator = new ClientValidator();
            _itemValidator = new ItemValidator();
            _imageValidator = new ImageValidator();
            _workerValidator = new WorkerValidator();
            _haircutValidator = new DutyValidator();
            _userValidator = new UserValidator();
        }

        public IValidator<UserEntity> InstanceUserValidator() => _userValidator;

        public IValidator<AddressEntity> InstanceAddressValidator() => _addressValidator;

        public IValidator<ClientEntity> InstanceClientValidator() => _clientValidator;

        public IValidator<EmployeeEntity> InstanceWorkerValidator() => _workerValidator;

        public IValidator<ServiceOrderEntity> InstanceDutyValidator() => _haircutValidator;

        public IValidator<ImageEntity> InstanceImageValidator() => _imageValidator;

        public IValidator<ProductEntity> InstanceItemValidator() => _itemValidator;
    }
}