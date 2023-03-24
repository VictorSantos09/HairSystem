using Hair.Application.Common;
using Hair.Application.Dto.ClientCases;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Functions
{
    /// <summary>
    /// 
    /// Responsável pelas funções referentes à busca de salões.
    /// 
    /// </summary>
    public class SearchSaloonFunction
    {
        private readonly IApplicationDbContext<UserEntity> _userRepository;

        public SearchSaloonFunction(IApplicationDbContext<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 
        /// Busca os salões que forem encontrados com o nome fornecido.
        /// 
        /// </summary>
        /// 
        /// <param name="dto">Contém os dados necessários para a busca.</param>
        /// 
        /// <returns> 
        /// 
        /// BaseDto que contém uma mensagem de sucesso e uma lista de objetos com informações sobre os salões encontrados.
        /// <para>Caso nenhum salão seja encontrado, a mensagem de sucesso conterá a indicação de que nenhum salão foi encontrado.</para>
        /// 
        /// </returns>
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
        /// 
        /// Busca os salões de forma mais precisa, filtrando se desejado apenas os abertos ou não.
        /// 
        /// </summary>
        /// 
        /// <param name="dto"></param>
        /// 
        /// <returns>
        /// O objeto BaseDto com os resultados da pesquisa de salões filtrados.
        /// </returns>
        public BaseDto FilteredSearch(SearchSaloonFilterDto dto)
        {
            var users = _userRepository.GetAll();

            if (users.Count == 0)
                return BaseDtoExtension.Sucess("Nehum salão disponível");

            if (dto.OnlyOpens)
                return FilterOpen(dto);

            return FilterClosed(dto);
        }

        private BaseDto FilterOpen(SearchSaloonFilterDto dto)
        {
            var users = _userRepository.GetAll();

            var actualTime = DateTime.Now.Hour;

            var saloonsMatch = users.FindAll(x => x.Address.City == dto.City && x.Address.Street == dto.Street && x.CloseTime.Hour < actualTime);

            if (saloonsMatch.Count == 0)
                return BaseDtoExtension.Sucess("Nehum salão encontrado");

            var saloons = BuildInformation(saloonsMatch);

            return BaseDtoExtension.Create(200, "Salões encontrados", saloons);
        }
        private BaseDto FilterClosed(SearchSaloonFilterDto dto)
        {
            var users = _userRepository.GetAll();

            var saloonsMatch = users.FindAll(x => x.Address.City == dto.City && x.Address.Street == dto.Street);

            if (saloonsMatch.Count == 0)
                return BaseDtoExtension.Sucess("Nehum salão encontrado");

            var saloons = BuildInformation(saloonsMatch);

            return BaseDtoExtension.Create(200, "Salões encontrados", saloons);
        }

        /// <summary>
        /// 
        /// Constrói um <see cref="object"/> com as informações visíveis para o usuário a partir dos usuários cadastrados.
        /// 
        /// </summary>
        /// 
        /// <param name="user">Usuário necessário para a conversão dos dados.</param>
        /// 
        /// <returns> Retorna o <see cref="object"/> com os dados que o usuário pode visualizar.</returns>
        private object? BuildInformation(UserEntity user)
        {
            return new
            {
                user.Address,
                OpenTime = Convert.ToString(user.OpenTime),
                CloseTime = Convert.ToString(user.CloseTime),
                user.Email,
                user.PhoneNumber,
                user.CNPJ,
                user.SaloonName,
            };
        }

        /// <summary>
        /// 
        /// Constrói um lista de <see cref="object"/> com as informações visíveis para o usuário a partir dos usuários cadastrados.
        /// 
        /// </summary>
        /// 
        /// <param name="users">Lista de usuários necessária para a conversão.</param>
        /// 
        /// <returns> Retorna uma <see cref="List{T}"/> de <see cref="object"/> com os dados que o usuário pode visualizar. </returns>
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