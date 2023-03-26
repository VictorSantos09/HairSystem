using Hair.Application.Common;
using Hair.Application.Dto.UserCases;

namespace Hair.Application.Interfaces.UserCases
{
    public interface ICreateUserService
    {
        BaseDto Create(CreateUserServiceDto dto);
    }
}