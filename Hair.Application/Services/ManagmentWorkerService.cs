using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Interfaces;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    public class ManagmentWorkerService : IManagmentWorkerService
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
        /// <param name="hireDto"></param>
        /// <returns>Retorna <see cref="BaseDto"/> com statusCode 200 e 404 caso o salão não foi encontrado</returns>
        public BaseDto HireNewbarber(HireBarberDto hireDto)
        {
            if (!hireDto.Confirmed)
                return BaseDtoExtension.RequestCanceled();

            var saloon = _userRepository.GetById(hireDto.SaloonId);

            if (saloon == null)
                return SaloonMessageExtension.SaloonNotFound();

            var barber = new BarberEntity(hireDto.Name, hireDto.PhoneNumber, hireDto.Email, hireDto.Salary, hireDto.Adress, true, saloon.Id, saloon.SaloonName);

            _barberRepository.Add(barber);

            return BaseDtoExtension.Create(200, $"{hireDto.Name} foi registrado");
        }
        /// <summary>
        /// Método para demissão de funcionarios
        /// </summary>
        /// <param name="fireDto"></param>
        /// <returns>Retorna um <see cref="BaseDto"/> Com statusCode 404,200 e 406 caso dados inválidos</returns>
        public BaseDto FireBarber(FireBarberDto fireDto)
        {
            var barber = _barberRepository.GetById(fireDto.BarberId);

            if (barber == null)
                return SaloonMessageExtension.BarberNotFound();

            if (fireDto.SaloonId == barber.JobSaloonId && fireDto.BarberName == barber.Name && fireDto.SaloonName == barber.JobSaloonName)
            {
                barber.Hired = false;
                _barberRepository.Remove(barber.Id);
                return BaseDtoExtension.Create(200, $"{barber.Name} foi demitido");
            }

            return BaseDtoExtension.InvalidData();
        }
        /// <summary>
        /// Efetua a mudança do nome do barbeiro
        /// </summary>
        /// <param name="barberNameDto"></param>
        /// <returns>retorna um <see cref="BaseDto"/> com status code 404, 200 ou 406</returns>
        public BaseDto ChangeBarberName(ChangeBarberNameDto barberNameDto)
        {
            var barber = _barberRepository.GetById(barberNameDto.BarberId);

            if (barber == null)
                return SaloonMessageExtension.BarberNotFound();

            var user = _userRepository.GetById(barberNameDto.SaloonId);

            if (user == null)
                return SaloonMessageExtension.SaloonNotFound();

            if (barber.JobSaloonId == user.Id && barberNameDto.BarberName == barber.Name)
            {
                barber.Name = barberNameDto.NewName;
                return BaseDtoExtension.Create(200, $"Nome alterado para {barberNameDto.NewName}");
            }

            return BaseDtoExtension.InvalidData();
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
                return SaloonMessageExtension.BarberNotFound();

            var user = _userRepository.GetById(salaryDto.SaloonId);

            if (user == null)
                return SaloonMessageExtension.SaloonNotFound();

            if (salaryDto.SaloonId == user.Id && salaryDto.BarberName == barber.Name)
            {
                barber.Salary = salaryDto.NewSalary;
                return BaseDtoExtension.Create(200, $"Salário de {barber.Name} alterado para {salaryDto.NewSalary}");
            }

            return BaseDtoExtension.InvalidData();
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
                return SaloonMessageExtension.BarberNotFound();

            var user = _userRepository.GetById(adressDto.SaloonId);

            if (user == null)
                return SaloonMessageExtension.SaloonNotFound();

            if (adressDto.SaloonId == user.Id && adressDto.BarberName == barber.Name)
            {
                barber.Adress = adressDto.NewAdress;
                return BaseDtoExtension.Create(200, $"Endereço de {barber.Name} alterado");
            }

            return BaseDtoExtension.InvalidData();
        }
    }
}