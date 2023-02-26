using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Domain.Interfaces;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    /// <summary>
    /// Conteém a efetuação da mudança de preços do corte de cabelo, barba e bigode
    /// </summary>
    public class ChangePriceService
    {
        private readonly IBaseRepository<IUser> _userRepository;
        private double _newPrice;

        public ChangePriceService(IBaseRepository<IUser> userRepository)
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

            if (double.IsNegative(dto.NewPrice) == true)
                return BaseDtoExtension.Invalid();

            _newPrice = dto.NewPrice;

            var user = _userRepository.GetById(dto.SaloonId);

            if (user == null)
                return BaseDtoExtension.NotFound();

            var haircutPlace = CheckAndApplyPrice(dto.Hair, dto.Mustache, dto.Beard, user);

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
        private bool CheckAndApplyPrice(bool hair, bool mustache, bool beard, IUser user)
        {
            if (!beard || !mustache || !beard)
                return false;

            if (hair)
                ApplyHairPrice(user);

            if (mustache)
                ApplyMustachePrice(user);


            if (beard)
                ApplyBeardPrice(user);

            return true;
        }
        private void ApplyHairPrice(IUser user)
        {
            user.Prices.Hair = _newPrice;

            _userRepository.Update(user);
        }
        private void ApplyBeardPrice(IUser user)
        {
            user.Prices.Beard = _newPrice;

            _userRepository.Update(user);
        }
        private void ApplyMustachePrice(IUser user)
        {
            user.Prices.Mustache = _newPrice;

            _userRepository.Update(user);
        }
    }
}