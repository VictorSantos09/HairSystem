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
        private IValidator<DutyEntity> _haircutValidator;
        private IValidator<WorkerEntity> _workerValidator;
        private IValidator<ItemEntity> _itemValidator;
        private IValidator<ImageEntity> _imageValidator;
        public ValidatorBuilder()
        {
            _addressValidator = new AddressValidator();
            _clientValidator = new ClientValidator();
            _itemValidator = new ItemValidator();
            _imageValidator = new ImageValidator();
            _workerValidator = new WorkerValidator(_addressValidator);
            _haircutValidator = new DutyValidator(_clientValidator);
            _userValidator = new UserValidator(_addressValidator);
        }

        public IValidator<UserEntity> InstanceUserValidator() => _userValidator;

        public IValidator<AddressEntity> InstanceAddressValidator() => _addressValidator;

        public IValidator<ClientEntity> InstanceClientValidator() => _clientValidator;

        public IValidator<WorkerEntity> InstanceWorkerValidator() => _workerValidator;

        public IValidator<DutyEntity> InstanceDutyValidator() => _haircutValidator;

        public IValidator<ImageEntity> InstanceImageValidator() => _imageValidator;

        public IValidator<ItemEntity> InstanceItemValidator() => _itemValidator;
    }
}