using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    /// <summary>
    /// 
    /// Define a função de ver as informações do salão.
    /// 
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
        /// Efetua a busca do salão e transfere suas informações pelo <paramref name="dto"/> fornecido.
        /// 
        /// </summary>
        /// 
        /// <param name="dto"></param>
        /// 
        /// <returns>Retorna <see cref="BaseDto"/> com mensagem e status code. Data de <see cref="BaseDto"/> recebe as informações do salão quando encontrado.</returns>
        public BaseDto GetInformation(ViewSaloonInformationDto dto)
        {
            var user = _userRepository.GetById(dto.UserId);

            if (user == null)
                return BaseDtoExtension.NotFound();

            var saloonInformation = BuildVisibleData(user);

            return BaseDtoExtension.Create(200, $"Informações do salão {user.SaloonName}", saloonInformation);
        }

        public BaseDto GetThreeSaloonsInfo()
        {
            var output = new List<object>();
            var users = _userRepository.GetAll();

            var random = new Random();

            var requestAmount = 3;

            for (int i = 0; i < requestAmount; i++)
            {
                var user = users[random.Next(users.Count)]; // não deixa repetir usuários

                var userConverted = BuildVisibleData(user);

                output.Add(userConverted);
            }

            return BaseDtoExtension.Create(200, $"{requestAmount} salões buscados", output);
        }

        private object BuildVisibleData(UserEntity user)
        {
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
                user.GoogleMapsSource,
                OpenTime = $"{user.OpenTime.Hour}:{user.OpenTime.Minute}",
                CloseTime = $"{user.CloseTime.Hour}:{user.CloseTime.Minute}",
            };

            return saloonInformation;
        }
    }
}