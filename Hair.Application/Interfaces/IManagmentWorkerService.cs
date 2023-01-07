using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Services;

namespace Hair.Application.Interfaces
{
    /// <summary>
    /// Interface para informar os metodos da service <see cref="ManagmentWorkerService"/>
    /// </summary>
    public interface IManagmentWorkerService
    {
        public BaseDto HireNewbarber(HireBarberDto hireDto);
        public BaseDto FireBarber(FireBarberDto fireDto);
        public BaseDto ChangeBarberName(ChangeBarberNameDto barberNameDto);
        public BaseDto ChangeBarberSalary(ChangeBarberSalaryDto salaryDto);
        public BaseDto ChangeBarberAddress(ChangeBarberAddressDto adressDto);
    }
}