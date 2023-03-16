using FluentValidation;
using Hair.Application.Services;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;

namespace Hair.Tests
{
    internal class ServiceProvider
    {
        private static readonly ValidatorProvider _validatorProvider = new ValidatorProvider();
        
        public static RegisterService InstanceRegisterService(Mock<IGetByEmail> iGetByEmailMock)
        {
            return new RegisterService(iGetByEmailMock.Object, _validatorProvider.InstanceUserValidator());
        }

        public LoginService InstanceLoginService(Mock<IGetByEmail> iGetByEmailMock)
        {
            return new LoginService(iGetByEmailMock.Object);
        }


        public ScheduleHaircutService InstanceScheduleHaircutService(Mock<IBaseRepository<UserEntity>> userRepositoryMock,
            Mock<IBaseRepository<HaircutEntity>> haircutRepositoryMock)
        {
            return new ScheduleHaircutService(userRepositoryMock.Object, haircutRepositoryMock.Object, _validatorProvider.InstanceHaircutValidator());

        }

        public ManagmentWorkerService InstanceManagmentWorkerService(Mock<IBaseRepository<UserEntity>> userRepositoryMock,
            Mock<IBaseRepository<BarberEntity>> barberRepositoryMock)
        {
            return new ManagmentWorkerService(userRepositoryMock.Object, barberRepositoryMock.Object, _validatorProvider.InstanceBarberValidator());
        }

        public CancelHaircutService InstanceCancelHaircutService(Mock<IBaseRepository<UserEntity>> userRepositoryMock,
            Mock<IBaseRepository<HaircutEntity>> haircutRepositoryMock)
        {
            return new CancelHaircutService(userRepositoryMock.Object, haircutRepositoryMock.Object);
        }
    }
}
