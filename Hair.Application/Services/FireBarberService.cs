using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    /// <summary>
    /// 
    /// Contém o método para efetuar a demissão de funcionários.
    /// 
    /// </summary>
    public class FireBarberService
    {
        private readonly IBaseRepository<BarberEntity> _barberRepository;

        public FireBarberService(IBaseRepository<BarberEntity> barberRepository)
        {
            _barberRepository = barberRepository;
        }

        /// <summary>
        /// 
        /// Método para demissão de funcionarios.
        /// 
        /// </summary>
        /// 
        /// <param name="dto">Objeto que contém dados do funcionário a ser demitido.</param>
        /// 
        /// <returns>Retorna a remoção do funcionário em caso de sucesso ou inválido.</returns>
        public BaseDto FireBarber(FireBarberDto dto)
        {
            var barber = _barberRepository.GetById(dto.BarberId);

            if (barber == null)
                return BaseDtoExtension.NotFound("Barbeiro");

            if (dto.SaloonId == barber.SaloonId && dto.BarberName.ToUpper() == barber.Name)
            {
                barber.Hired = false;

                _barberRepository.Remove(barber.Id);

                return BaseDtoExtension.Sucess($"{barber.Name} foi demitido");
            }

            return BaseDtoExtension.Create(406, "Não foi possivel encontrar o barbeiro no salão");
        }
    }
}
