using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Moq;
using System.Threading;
using static Xunit.Assert;

namespace Hair.Tests.Services
{
    public class ManagmentWorkerTest
    {
        private readonly ManagmentWorkerService _service;
        private readonly GlobalUser _globalUser;
        private readonly UserEntity _user;
        private readonly HireBarberDto _hireBarberDtoTrue;
        private readonly HireBarberDto _hireBarberDtoFalse;
        private readonly BarberEntity _barber;
        private readonly Mock<IBaseRepository<UserEntity>> _userRepository = new Mock<IBaseRepository<UserEntity>>();
        private readonly Mock<IBaseRepository<BarberEntity>> _barberRepository = new Mock<IBaseRepository<BarberEntity>>();

        public ManagmentWorkerTest()
        {
            _globalUser = new GlobalUser();
            _service = new ManagmentWorkerService(_userRepository.Object, _barberRepository.Object);
            _user = _globalUser.GetGlobalUser();
            _barber = _globalUser.GetBarber();
            _hireBarberDtoTrue = new HireBarberDto("Victor", null, null, 2000, _user.Adress, _user.Id, true);
            _hireBarberDtoFalse = new HireBarberDto("Victor", null, null, 2000, _user.Adress, _user.Id, false);
        }

        [Fact]
        private void HireNewBarber_ShouldReturn200_WhenConfirmedFalse()
        {
            var actual = _service.HireNewbarber(_hireBarberDtoFalse);

            var expected = new BaseDto(200, "Solicitação cancelada");
            
            Equal(expected._StatusCode, actual._StatusCode);
            Equal(expected._Message, actual._Message);
        }
        [Fact]
        private void HireNewBarber_ShouldReturn404_WhenUserNotFound()
        {
            _barberRepository.Setup(x => x.GetById(_user.Id));
            
            var hireDto = new HireBarberDto("Victor", null, null, 2000, _user.Adress, It.IsAny<Guid>(), true);

            var actual = _service.HireNewbarber(hireDto);

            var expected = new BaseDto(404, "Não foi possivel encontrar o salão");

            Equal(expected._StatusCode, actual._StatusCode);
            Equal(expected._Message, actual._Message);
        }
        [Fact]
        private void HireNewBarber_ShouldReturn200_WhenSucessfullHire()
        {
            _barberRepository.Setup(x => x.Add(_barber));
            _userRepository.Setup(x => x.GetById(_user.Id)).Returns(_user);

            var actual = _service.HireNewbarber(_hireBarberDtoTrue);
            
            var expected = new BaseDto(200, $"{_hireBarberDtoTrue.Name} foi registrado");

            Equal(expected._StatusCode, actual._StatusCode);
            Equal(expected._Message, actual._Message);
        }
        [Fact]
        private void FireBarber_ShouldReturn404_WhenBarberNotFound()
        {
            _barberRepository.Setup(x => x.GetById(It.IsAny<Guid>()));

            var fireDto = new FireBarberDto(_user.Id, It.IsAny<Guid>(), _barber.Name, _barber.Email, _user.SaloonName);

            var actual = _service.FireBarber(fireDto);

            var expected = new BaseDto(404, "Não foi possível encontrar o barbeiro");

            Equal(expected._StatusCode, actual._StatusCode);
            Equal(expected._Message, actual._Message);
        }
        [Fact]
        private void FireBarber_ShouldReturn200_WhenCorrectData()
        {
            _barberRepository.Setup(x => x.GetById(_barber.Id)).Returns(_barber);
            _barberRepository.Setup(x => x.Remove(_barber.Id));

            var fireDto = new FireBarberDto(_user.Id, _barber.Id, _barber.Name, _barber.Email, _user.SaloonName);

            var actual = _service.FireBarber(fireDto);
            
            var expected = new BaseDto(200, $"{_barber.Name} foi demitido");

            Equal(expected._StatusCode, actual._StatusCode);
            Equal(expected._Message, actual._Message);
        }
        [Fact]
        private void FireBarber_ShouldReturn406_WhenIncorrectData()
        {
            _barberRepository.Setup(x => x.GetById(_barber.Id)).Returns(_barber);

            var fireDto = new FireBarberDto(_user.Id, _barber.Id, "Alberto Chavez", _barber.Email, _user.SaloonName);

            var actual = _service.FireBarber(fireDto);

            var expected = new BaseDto(406, "Dados inválidos, solicitação cancelada");

            Equal(expected._StatusCode, actual._StatusCode);
            Equal(expected._Message, actual._Message);
        }
    }
}
