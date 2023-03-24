using Hair.Application.Services.ClientCases;
using Hair.Application.Services.UserCases.EmployeeManagment;
using Hair.Application.Services.UserCases.UserAccountManagment;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Hair.Repository.Interfaces.CRUD;
using Moq;

namespace Hair.Tests.Builders
{
    internal sealed class ServiceBuilder
    {
        private static readonly ValidatorBuilder _validatorBuilder = new ValidatorBuilder();

        public static RegisterService InstanceRegister(Mock<IGetByEmailDbContext> iGetByEmailMock)
        {
            return new RegisterService(iGetByEmailMock.Object, _validatorBuilder.InstanceUserValidator());
        }

        public LoginService InstanceLogin(Mock<IGetByEmailDbContext> iGetByEmailMock)
        {
            return new LoginService(iGetByEmailMock.Object);
        }

        public ScheduleDutyService InstanceScheduleHaircut(Mock<IApplicationDbContext<UserEntity>> userRepositoryMock,
            Mock<IApplicationDbContext<ServiceOrderEntity>> dutyRepositoryMock)
        {
            return new ScheduleDutyService(userRepositoryMock.Object, dutyRepositoryMock.Object, _validatorBuilder.InstanceDutyValidator());
        }

        public EmployeeManagmentService InstanceManagmentWorker(Mock<IApplicationDbContext<UserEntity>> userRepositoryMock,
            Mock<IApplicationDbContext<EmployeeEntity>> workerRepositoryMock, Mock<IFunctionTypeRequestDbContext> functionTypeRepository)
        {
            return new EmployeeManagmentService(userRepositoryMock.Object, workerRepositoryMock.Object, _validatorBuilder.InstanceWorkerValidator(), functionTypeRepository.Object);
        }

        public CancelDutyService InstanceCancelHaircut(Mock<IApplicationDbContext<UserEntity>> userRepositoryMock,
            Mock<IApplicationDbContext<ServiceOrderEntity>> dutyRepositoryMock)
        {
            return new CancelDutyService(userRepositoryMock.Object, dutyRepositoryMock.Object);
        }

        public CreateEmployeeService InstanceHireWorker(Mock<IApplicationDbContext<UserEntity>> userRepositoryMock, Mock<IApplicationDbContext<EmployeeEntity>> workerRepositoryMock)
        {
            return new CreateEmployeeService(userRepositoryMock.Object, workerRepositoryMock.Object, _validatorBuilder.InstanceWorkerValidator());
        }
    }
}