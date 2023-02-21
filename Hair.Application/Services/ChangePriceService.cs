using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    /// <summary>
    /// Conteém a efetuação da mudança de preços do corte de cabelo, barba e bigode
    /// </summary>
    public class ChangePriceService
    {
        private readonly IBaseRepository<UserEntity> _userRepository;
        private double _newPrice;
        private Guid _userId;

        public ChangePriceService(IBaseRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }
        /// <summary>
        /// 
        /// Verifica a confirmação e efetua a alteração dos valores de cortes de cabelo, barba e bigode
        /// 
        /// </summary>
        /// 
        /// <param name="dto"></param>
        /// 
        /// <returns>Retorna <see cref="BaseDto"/> com mensagem e status code dependendo da condição encontrada</returns>
        public BaseDto ChangeHaircutePrice(ChangePriceDto dto)
        {
            if (!dto.Confirmed)
                return BaseDtoExtension.RequestCanceled();

            _userId = dto.SaloonId;
            _newPrice = dto.NewPrice;

            if (double.IsNegative(dto.NewPrice) == true)
                return BaseDtoExtension.Invalid();

            var user = _userRepository.GetById(dto.SaloonId);

            if (user == null)
                return BaseDtoExtension.NotFound();

            var haircutPlace = CheckAndApplyPrice(dto.Hair, dto.Mustache, dto.Beard);

            if (!haircutPlace)
                return BaseDtoExtension.Create(406, "Escolha algum item");

            return BaseDtoExtension.Sucess("Alteração Concluída");
        }
        /// <summary>
        /// 
        /// Verifica as condições verdadeiras e aplica no tipo de corte true da Id do Salão
        /// 
        /// </summary>
        /// 
        /// <param name="hair"></param>
        /// <param name="mustache"></param>
        /// <param name="beard"></param>
        /// 
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
            var user = _userRepository.GetById(_userId);

            user.Prices.Hair = _newPrice;
        }
        private void ApplyBeardPrice()
        {
            var user = _userRepository.GetById(_userId);

            user.Prices.Beard = _newPrice;
        }
        private void ApplyMustachePrice()
        {
            var user = _userRepository.GetById(_userId);

            user.Prices.Mustache = _newPrice;
        }
    }
}