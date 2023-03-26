using Hair.Application.Common;
using Hair.Application.Dto.UserCases;
using Hair.Application.Extensions;
using Hair.Application.Interfaces.UserCases;
using Hair.Repository.Interfaces.Repositories;

namespace Hair.Application.Services.UserCases.ServiceOrderManagment
{
    /// <summary>
    /// Efetua a busca de todos as ordens de serviço agendadas para o usuário.
    /// </summary>
    public class ViewServiceOrderService : IViewServiceOrder
    {
        private readonly IServiceOrderRepository _serviceOrderRepository;

        public ViewServiceOrderService(IServiceOrderRepository serviceOrderRepository)
        {
            _serviceOrderRepository = serviceOrderRepository;
        }

        public BaseDto GetActivatedOrders(ViewDutyTimeDto dto)
        {
            var userOrders = _serviceOrderRepository.GetAllByUserId(dto.UserID);

            if (userOrders.Count == 0)
            {
                return BaseDtoExtension.Create(200, "Não foram encontrados ordens de serviços agendadas.");
            }

            return BaseDtoExtension.Create(200, "Lista de ordens de serviços encontradas.", userOrders);
        }
    }
}
