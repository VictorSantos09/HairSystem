using FluentValidation;
using Hair.Application.Services;
using Hair.Application.Validators;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;

namespace Hair.Tests.Builders
{
    internal sealed class ServiceBuilder
    {
        private static readonly ValidatorBuilder _validatorBuilder = new ValidatorBuilder();

        public static RegisterService InstanceRegister(Mock<IGetByEmail> iGetByEmailMock)
        {
            return new RegisterService(iGetByEmailMock.Object, _validatorBuilder.InstanceUserValidator());
        }

        public LoginService InstanceLogin(Mock<IGetByEmail> iGetByEmailMock)
        {
            return new LoginService(iGetByEmailMock.Object);
        }

        public ScheduleHaircutService InstanceScheduleHaircut(Mock<IBaseRepository<UserEntity>> userRepositoryMock,
            Mock<IBaseRepository<DutyEntity>> haircutRepositoryMock)
        {
            return new ScheduleHaircutService(userRepositoryMock.Object, haircutRepositoryMock.Object, _validatorBuilder.InstanceHaircutValidator());
        }

        public ManagmentWorkerService InstanceManagmentWorker(Mock<IBaseRepository<UserEntity>> userRepositoryMock,
            Mock<IBaseRepository<BarberEntity>> barberRepositoryMock)
        {
            return new ManagmentWorkerService(userRepositoryMock.Object, barberRepositoryMock.Object, _validatorBuilder.InstanceBarberValidator());
        }

        public CancelHaircutService InstanceCancelHaircut(Mock<IBaseRepository<UserEntity>> userRepositoryMock,
            Mock<IBaseRepository<DutyEntity>> haircutRepositoryMock)
        {
            return new CancelHaircutService(userRepositoryMock.Object, haircutRepositoryMock.Object);
        }

        public HireBarberService InstanceHireWorker(Mock<IBaseRepository<UserEntity>> userRepositoryMock, Mock<IBaseRepository<BarberEntity>> barberRepositoryMock)
        {
            return new HireBarberService(userRepositoryMock.Object, barberRepositoryMock.Object, _validatorBuilder.InstanceBarberValidator());
        }
    }
}