using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;

namespace Hair.Application.Services
{
    public class ScheduleHaircutService
    {
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly IBaseRepository<HaircutEntity> _haircutRepository;

        public ScheduleHaircutService(IBaseRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        public BaseDto Schedule(ScheduleHaircutDto dto)
        {
            var user = _userRepository.GetById(dto.UserID);

            var haircute = new HaircutEntity(dto.UserID, dto.HaircuteTime, dto.Confirmed, dto.Client);

            user.Haircutes.Add(haircute);
        }
    }
}