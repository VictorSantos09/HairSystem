using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Interfaces;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    /// <summary>
    /// Classe para efetuação da mudança de preços do corte de cabelo, barba e bigode
    /// </summary>
    public class ChangePriceService
    {
        private readonly IBaseRepository<UserEntity> _userRepository;
        private double _newPrice;
        private Guid _saloonId;

        public ChangePriceService(IBaseRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }
        /// <summary>
        /// Verifica a confirmação e efetua a aplicação da alteração dos valores de cortes de cabelo, barba e bigode
        /// </summary>
        /// <param name="newPrice"></param>
        /// <param name="saloonId"></param>
        /// <param name="confirmed"></param>
        /// <param name="hair"></param>
        /// <param name="mustache"></param>
        /// <param name="beard"></param>
        /// <returns>retorna um <see cref="BaseDto"/> com statusCode 404,406 e 200</returns>
        public BaseDto ChangeHaircutePrice(ChangePriceDto dto)
        {
            if (!dto.Confirmed)
                return BaseDtoExtension.RequestCanceled();

            _saloonId = dto.SaloonId;
            _newPrice = dto.NewPrice;

            if (double.IsNegative(dto.NewPrice) == true)
                return BaseDtoExtension.Invalid();

            var user = _userRepository.GetById(dto.SaloonId);

            if (user == null)
                return UserMessageExtension.UserNotFound();

            var haircutePlace = CheckAndApplyPrice(dto.Hair, dto.Mustache, dto.Beard);

            if (!haircutePlace)
                return BaseDtoExtension.Create(406, "Escolha algum item");

            return BaseDtoExtension.Sucess("Alteração Concluída");
        }
        /// <summary>
        /// Verifica as condições verdadeiras e aplica no tipo de corte true da Id do Salão
        /// </summary>
        /// <param name="hair"></param>
        /// <param name="mustache"></param>
        /// <param name="beard"></param>
        /// <returns>Retorna false casos os parametros sejam falsos, e true caso algum verdadeiro após aplicação</returns>
        private bool CheckAndApplyPrice(bool hair, bool mustache, bool beard)
        {
            if (!beard || !mustache || !beard)
                return false;

            if (hair)
                ApplyHairPrice();

            if (mustache)
                ApplyMustachePrice();


            if (beard)
                ApplyBeardPrice();

            return true;
        }
        private void ApplyHairPrice()
        {
            var saloon = _userRepository.GetById(_saloonId);

            saloon.Prices.Hair = _newPrice;
        }
        private void ApplyBeardPrice()
        {
            var saloon = _userRepository.GetById(_saloonId);

            saloon.Prices.Beard = _newPrice;
        }
        private void ApplyMustachePrice()
        {
            var saloon = _userRepository.GetById(_saloonId);

            saloon.Prices.Mustache = _newPrice;
        }
    }
}