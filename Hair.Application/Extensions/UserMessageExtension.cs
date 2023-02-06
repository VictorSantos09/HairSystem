using Hair.Application.Common;

namespace Hair.Application.Extensions
{
    public class UserMessageExtension
    {
        public static BaseDto UserNotFound()
        {
            return new BaseDto(404, "Usuário não encontrado");
        }
    }
}