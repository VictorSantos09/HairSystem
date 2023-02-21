using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    /// <summary>
    /// Classe para gerenciamento do Funcionário, como contratar, demitir entre outros
    /// </summary>
    public class ManagmentWorkerService
    {
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly IBaseRepository<BarberEntity> _barberRepository;

        public ManagmentWorkerService(IBaseRepository<UserEntity> userRepository, IBaseRepository<BarberEntity> barberRepository)
        {
            _userRepository = userRepository;
            _barberRepository = barberRepository;
        }

        /// <summary>
        /// Método para contratação de novo barbeiro se confirmado true
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Retorna <see cref="BaseDto"/> com statusCode 200 e 404 caso o salão não foi encontrado</returns>
        public BaseDto HireNewbarber(HireBarberDto dto)
        {
            if (!dto.Confirmed)
                return BaseDtoExtension.RequestCanceled();

            var user = _userRepository.GetById(dto.SaloonId);

            if (user == null)
                return BaseDtoExtension.NotFound();

            var barber = new BarberEntity(dto.Name, dto.PhoneNumber, dto.Email, dto.Salary, dto.Adress, true, user.Id, user.SaloonName);

            _barberRepository.Create(barber);

            return BaseDtoExtension.Create(200, $"{dto.Name} foi registrado");
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

            if (dto.SaloonId == barber.SaloonId && dto.BarberName == barber.Name && dto.SaloonName == barber.SaloonName)
            {
                barber.Hired = false;

                _barberRepository.Remove(barber.Id);
                
                return BaseDtoExtension.Sucess($"{barber.Name} foi demitido");
            }

            return BaseDtoExtension.Create(406,"Não foi possivel efetuar a demissão");
        }
        /// <summary>
        /// Efetua a mudança do nome do barbeiro
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>retorna um <see cref="BaseDto"/> com status code 404, 200 ou 406</returns>
        public BaseDto ChangeBarberName(ChangeBarberNameDto dto)
        {
            var barber = _barberRepository.GetById(dto.BarberId);

            if (barber == null)
                return BaseDtoExtension.NotFound("Barbeiro");

            var user = _userRepository.GetById(dto.SaloonId);

            if (user == null)
                return BaseDtoExtension.NotFound();

            if (barber.SaloonId == user.Id && dto.BarberName == barber.Name)
            {
                barber.Name = dto.NewName;
                return BaseDtoExtension.Create(200, $"Nome alterado para {dto.NewName}");
            }

            return BaseDtoExtension.Create(406, "Não foi possivel efetuar a alteração do nome");
        }
        /// <summary>
        /// Efetua a mudança do salario do barbeiro
        /// </summary>
        /// <param name="salaryDto"></param>
        /// <returns>retorna um <see cref="BaseDto"/> com status code 404, 406 e 200</returns>
        public BaseDto ChangeBarberSalary(ChangeBarberSalaryDto salaryDto)
        {
            var barber = _barberRepository.GetById(salaryDto.BarberId);

            if (barber == null)
                return BaseDtoExtension.NotFound("Barbeiro");

            var user = _userRepository.GetById(salaryDto.SaloonId);

            if (user == null)
                return BaseDtoExtension.NotFound();

            if (salaryDto.SaloonId == user.Id && salaryDto.BarberName == barber.Name)
            {
                barber.Salary = salaryDto.NewSalary;
                return BaseDtoExtension.Create(200, $"Salário de {barber.Name} alterado para {salaryDto.NewSalary}");
            }

            return BaseDtoExtension.Create(406, "Não foi possivel efetuar a alteração do salário");
        }
        /// <summary>
        /// Efetua a mudança do endereço do barbeiro
        /// </summary>
        /// <param name="adressDto"></param>
        /// <returns>Retorna um <see cref="BaseDto"/> com status code 404, 406 e 200</returns>
        public BaseDto ChangeBarberAddress(ChangeBarberAddressDto adressDto)
        {
            var barber = _barberRepository.GetById(adressDto.BarberId);

            if (barber == null)
                return BaseDtoExtension.NotFound("Barbeiro");

            var user = _userRepository.GetById(adressDto.SaloonId);

            if (user == null)
                return BaseDtoExtension.NotFound();

            if (adressDto.SaloonId == user.Id && adressDto.BarberName == barber.Name)
            {
                barber.Address = adressDto.NewAdress;
                return BaseDtoExtension.Create(200, $"Endereço de {barber.Name} alterado");
            }

            return BaseDtoExtension.Create(406, "Não foi possivel efetuar a alteração do endereço");
        }
    }
}