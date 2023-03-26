using Hair.Application.Common;
using Hair.Application.Dto.UserCases;

namespace Hair.Application.Interfaces.UserCases
{
    public interface IDeleteUserService
    {
        BaseDto Delete(DeleteUserServiceDto dto);
    }
}