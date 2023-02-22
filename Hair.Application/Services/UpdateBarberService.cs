using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    /// <summary>
    /// Define os métodos para atualização de funcionário
    /// </summary>
    public class UpdateBarberService
    {
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly IBaseRepository<BarberEntity> _barberRepository;

        public UpdateBarberService(IBaseRepository<UserEntity> userRepository, IBaseRepository<BarberEntity> barberRepository)
        {
            _userRepository = userRepository;
            _barberRepository = barberRepository;
        }

        /// <summary>
        /// 
        /// Efetua a atualização de um novo barbeiro
        /// 
        /// </summary>
        /// 
        /// <param name="dto">Dados necessários para atualizar</param>
        /// 
        /// <returns>Retorna <see cref="BaseDto"/> com mensagem e status code dependendo da condição encontrada</returns>
        public BaseDto Update(UpdateBarberDto dto)
        {
            var user = _userRepository.GetById(dto.UserId);

            if (user == null)
                return BaseDtoExtension.NotFound();

            var allBarbers = _barberRepository.GetAll().FindAll(x => x.SaloonId == user.Id);

            if (allBarbers.Count == 0)
                return BaseDtoExtension.Create(404, "Nenhum barbeiro foi encontrado");

            var barberToUpdate = allBarbers.Find(x => x.Name == dto.BarberName || x.PhoneNumber == dto.BarberPhoneNumber);

            if (barberToUpdate == null)
                return BaseDtoExtension.NotFound("Barbeiro para atualizar");

            var barberUpdated = new BarberEntity(dto.NewName, dto.NewPhoneNumber, dto.NewEmail, dto.NewSalary, dto.NewAddress, true, user.Id, user.SaloonName);

            barberToUpdate = barberUpdated;

            _barberRepository.Update(barberToUpdate);

            return BaseDtoExtension.Sucess($"Dados de {barberToUpdate.Name} atualizados");

        }
    }
}