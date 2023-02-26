using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Functions
{
    /// <summary>
    /// Responsável pelas funções referentes a busca de salões
    /// </summary>
    public class SearchSaloonFunction
    {
        private readonly IBaseRepository<UserEntity> _userRepository;

        public SearchSaloonFunction(IBaseRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Busca os salões que forem encontrados com o nome fornecido
        /// </summary>
        /// <param name="dto">Contém os dados necessários para a busca</param>
        /// <returns></returns>
        public BaseDto SimpleSearch(SearchSaloonSimpleDto dto)
        {
            var users = _userRepository.GetAll();

            if (users.Count == 0)
                return BaseDtoExtension.Sucess("Nenhum salão disponível");

            var saloonsMatch = users.FindAll(x => x.SaloonName == dto.SaloonName);

            if (saloonsMatch.Count == 0)
                return BaseDtoExtension.Sucess("Nenhum salão encontrado");

            var saloons = BuildInformation(saloonsMatch);

            return BaseDtoExtension.Create(200, $"Salões com nome {dto.SaloonName} encontrados", saloons);
        }

        /// <summary>
        /// Busca os salões de forma mais precisa, filtrando se desejado apenas os abertos ou não
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public BaseDto Filtered(SearchSaloonFilterDto dto)
        {
            var users = _userRepository.GetAll();

            if (users.Count == 0)
                return BaseDtoExtension.Sucess("Nehum salão disponível");

            if (dto.OnlyOpens)
                return FilterOpens(dto);

            return FilterCloseds(dto);
        }

        private BaseDto FilterOpens(SearchSaloonFilterDto dto)
        {
            var users = _userRepository.GetAll();

            var actualTime = DateTime.Now.Hour;

            var saloonsMatch = users.FindAll(x => x.Address.City == dto.City && x.Address.Street == dto.Street && x.CloseTime.Hour < actualTime);

            if (saloonsMatch.Count == 0)
                return BaseDtoExtension.Sucess("Nehum salão encontrado");

            var saloons = BuildInformation(saloonsMatch);

            return BaseDtoExtension.Create(200, "Salões encontrados", saloons);
        }
        private BaseDto FilterCloseds(SearchSaloonFilterDto dto)
        {
            var users = _userRepository.GetAll();

            var saloonsMatch = users.FindAll(x => x.Address.City == dto.City && x.Address.Street == dto.Street);

            if (saloonsMatch.Count == 0)
                return BaseDtoExtension.Sucess("Nehum salão encontrado");

            var saloons = BuildInformation(saloonsMatch);

            return BaseDtoExtension.Create(200, "Salões encontrados", saloons);
        }

        private object? BuildInformation(UserEntity user)
        {
            return new
            {
                user.Address.Number,
                user.Address.City,
                user.Address.State,
                user.Address.Complement,
                user.OpenTime,
                user.CloseTime,
                user.Email,
                user.PhoneNumber,
                user.CNPJ,
                user.SaloonName,
            };
        }

        private List<object>? BuildInformation(List<UserEntity> users)
        {
            var usersOutput = new List<object>();

            foreach (var user in users)
            {
                usersOutput.Add(BuildInformation(user));
            }

            return usersOutput;
        }
    }
}