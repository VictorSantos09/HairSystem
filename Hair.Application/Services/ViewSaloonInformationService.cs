using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    /// <summary>
    /// Define a função de ver as informações do salao
    /// </summary>
    public class ViewSaloonInformationService
    {
        private readonly IBaseRepository<UserEntity> _userRepository;

        public ViewSaloonInformationService(IBaseRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 
        /// Efetua a busca do salão e transfere suas informações pelo <paramref name="dto"/> fornecido
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// 
        /// <returns>Retorna <see cref="BaseDto"/> com mensagem e status code. Data de <see cref="BaseDto"/> recebe as informações do salão quando encontrado</returns>
        public BaseDto GetInformation(ViewSaloonInformationDto dto)
        {
            var user = _userRepository.GetById(dto.UserId);

            if (user == null)
                return BaseDtoExtension.NotFound();

            object saloonInformation = new
            {
                user.Address,
                user.PhoneNumber,
                user.Email,
                user.SaloonName,
                user.Prices.Hair,
                user.Prices.Beard,
                user.Prices.Mustache,
                user.CNPJ,
            };

            return BaseDtoExtension.Create(200, $"Informações do salão {user.SaloonName}", saloonInformation);
        }
    }
}