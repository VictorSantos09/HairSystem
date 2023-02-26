using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Domain.Interfaces;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    /// <summary>
    /// Contém o método para efetuar a demissão de funcionários
    /// </summary>
    public class FireBarberService
    {
        private readonly IBaseRepository<IBarber> _barberRepository;

        public FireBarberService(IBaseRepository<IBarber> barberRepository)
        {
            _barberRepository = barberRepository;
        }

        /// <summary>
        /// Método para demissão de funcionarios
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Retorna um <see cref="BaseDto"/> Com statusCode 404,200 e 406 caso dados inválidos</returns>
        public BaseDto FireBarber(FireBarberDto dto)
        {
            var barber = _barberRepository.GetById(dto.BarberId);

            if (barber == null)
                return BaseDtoExtension.NotFound("Barbeiro");

            if (dto.SaloonId == barber.SaloonId && dto.BarberName == barber.Name)
            {
                barber.Hired = false;

                _barberRepository.Remove(barber.Id);

                return BaseDtoExtension.Sucess($"{barber.Name} foi demitido");
            }

            return BaseDtoExtension.Create(406, "Não foi possivel encontrar o barbeiro no salão");
        }
    }
}
