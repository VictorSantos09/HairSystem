using Hair.Application.Common;
using Hair.Application.Dto.UserCases;

namespace Hair.Application.Interfaces.UserCases
{
    public interface IViewServiceOrder
    {
        BaseDto GetActivatedOrders(ViewDutyTimeDto dto);
    }
}