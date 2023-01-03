using Application.Dto;
using Hair.Application.Interfaces;
using Repository.Repository;

namespace Hair.Application.Services
{
    public class ChangePriceService : IChangePriceService
    {
        private readonly UserRepository _userRepository;
        private double _newPrice;
        private Guid _saloonId;

        public ChangePriceService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public BaseDto ChangeHaircutePrice(double newPrice, Guid saloonId, bool confirmed, bool hair, bool mustache, bool beard)
        {
            if (!confirmed)
                return new BaseDto(200, "Solicitação cancelada");

            _saloonId = saloonId;
            _newPrice = newPrice;

            if (double.IsNormal(newPrice) == false || double.IsNegative(newPrice) == true)
                return new BaseDto(406, "Valor não permitido");

            var saloon = _userRepository.GetById(saloonId);
            
            if (saloon == null)
                return new BaseDto(404, "Usuário não encontrado");

            var haircutePlace = CheckAndApplyPrice(hair, mustache, beard);

            if (!haircutePlace)
                return new BaseDto(406, "Não foi possivel finalizar sua solicitação");

            return new BaseDto(200, $"Valor do corte alterado para {newPrice}");
        }
        private bool CheckAndApplyPrice(bool hair, bool mustache, bool beard)
        {
            if (hair)
                return ApplyHairPrice();

            else if (mustache)
                return ApplyMustachePrice();

            else if (beard)
                return ApplyBeardPrice();

            return false;
        }
        private bool ApplyHairPrice()
        {
            var saloon = _userRepository.GetById(_saloonId);

            if (saloon == null)
                return false;
            
            saloon.PriceEntity.Hair = _newPrice;

            return true;
        }
        private bool ApplyBeardPrice()
        {
            var saloon = _userRepository.GetById(_saloonId);

            if (saloon == null)
                return false;

            saloon.PriceEntity.Beard = _newPrice;
         
            return true;
        }
        private bool ApplyMustachePrice()
        {
            var saloon = _userRepository.GetById(_saloonId);

            if (saloon == null)
                return false;

            saloon.PriceEntity.Mustache = _newPrice;
         
            return true;
        }
    }
}