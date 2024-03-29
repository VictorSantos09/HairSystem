﻿using Hair.Application.Services;
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
            Mock<IBaseRepository<DutyEntity>> dutyRepositoryMock)
        {
            return new ScheduleDutyService(userRepositoryMock.Object, dutyRepositoryMock.Object, _validatorBuilder.InstanceDutyValidator());
        }

        public ManagmentWorkerService InstanceManagmentWorker(Mock<IBaseRepository<UserEntity>> userRepositoryMock,
            Mock<IBaseRepository<WorkerEntity>> workerRepositoryMock, Mock<IFunctionTypeRequest> functionTypeRepository)
        {
            return new ManagmentWorkerService(userRepositoryMock.Object, workerRepositoryMock.Object, _validatorBuilder.InstanceWorkerValidator(), functionTypeRepository.Object);
        }

        public CancelHaircutService InstanceCancelHaircut(Mock<IBaseRepository<UserEntity>> userRepositoryMock,
            Mock<IBaseRepository<DutyEntity>> dutyRepositoryMock)
        {
            return new CancelHaircutService(userRepositoryMock.Object, dutyRepositoryMock.Object);
        }

        public HireWorkerService InstanceHireWorker(Mock<IBaseRepository<UserEntity>> userRepositoryMock, Mock<IBaseRepository<WorkerEntity>> workerRepositoryMock)
        {
            return new HireWorkerService(userRepositoryMock.Object, workerRepositoryMock.Object, _validatorBuilder.InstanceWorkerValidator());
        }
    }
}