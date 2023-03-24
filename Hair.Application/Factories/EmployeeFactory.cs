using Hair.Domain.Entities;

namespace Hair.Application.Factories
{
    public class EmployeeFactory
    {
       public EmployeeEntity Create() => new EmployeeEntity();
        public EmployeeEntity Create(string name, string phoneNumber, string? email, float salary,
            AddressEntity address, Guid userID, FunctionTypeEntity functionType)
        {
            return new EmployeeEntity(name,phoneNumber,email,salary,address,userID,functionType);
        }
    }
}