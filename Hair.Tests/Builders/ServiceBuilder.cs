using Hair.Application.Services.ClientCases;
using Hair.Application.Services.UserCases.EmployeeManagment;
using Hair.Application.Services.UserCases.UserAccountManagment;
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

        public ScheduleDutyService InstanceScheduleHaircut(Mock<IBaseRepository<UserEntity>> userRepositoryMock,
            Mock<IBaseRepository<ServiceOrderEntity>> dutyRepositoryMock)
        {
            return new ScheduleDutyService(userRepositoryMock.Object, dutyRepositoryMock.Object, _validatorBuilder.InstanceDutyValidator());
        }

        public EmployeeManagmentService InstanceManagmentWorker(Mock<IBaseRepository<UserEntity>> userRepositoryMock,
            Mock<IBaseRepository<EmployeeEntity>> workerRepositoryMock, Mock<IFunctionTypeRequest> functionTypeRepository)
        {
            return new EmployeeManagmentService(userRepositoryMock.Object, workerRepositoryMock.Object, _validatorBuilder.InstanceWorkerValidator(), functionTypeRepository.Object);
        }

        public CancelDutyService InstanceCancelHaircut(Mock<IBaseRepository<UserEntity>> userRepositoryMock,
            Mock<IBaseRepository<ServiceOrderEntity>> dutyRepositoryMock)
        {
            return new CancelDutyService(userRepositoryMock.Object, dutyRepositoryMock.Object);
        }

        public CreateEmployeeService InstanceHireWorker(Mock<IBaseRepository<UserEntity>> userRepositoryMock, Mock<IBaseRepository<EmployeeEntity>> workerRepositoryMock)
        {
            return new CreateEmployeeService(userRepositoryMock.Object, workerRepositoryMock.Object, _validatorBuilder.InstanceWorkerValidator());
        }
    }
}