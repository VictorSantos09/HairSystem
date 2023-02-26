using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Domain.Interfaces;
using Hair.Repository.Interfaces;

namespace Hair.Application.Functions
{
    /// <summary>
    /// Responsável pelas funções referentes a busca de salões
    /// </summary>
    public class SearchSaloonFunction
    {
        private readonly IBaseRepository<IUser> _userRepository;

        public SearchSaloonFunction(IBaseRepository<IUser> userRepository)
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

            return BaseDtoExtension.Create(200, $"Salões com nome {dto.SaloonName} encontrados", saloonsMatch);
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

            return BaseDtoExtension.Create(200, "Salões encontrados", saloonsMatch);
        }
        private BaseDto FilterCloseds(SearchSaloonFilterDto dto)
        {
            var users = _userRepository.GetAll();

            var saloonsMatch = users.FindAll(x => x.Address.City == dto.City && x.Address.Street == dto.Street);

            if (saloonsMatch.Count == 0)
                return BaseDtoExtension.Sucess("Nehum salão encontrado");

            return BaseDtoExtension.Create(200, "Salões encontrados", saloonsMatch);
        }
    }
}