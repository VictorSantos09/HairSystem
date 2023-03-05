﻿using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.ExceptionHandlling;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class ManagmentWorkerController : ControllerBase
    {
        private readonly ManagmentWorkerService _service;
        private readonly IBaseRepository<BarberEntity> _barberRepository;
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly IException _exHelper;

        public ManagmentWorkerController(IBaseRepository<BarberEntity> barberRepository, IBaseRepository<UserEntity> userRepository, IException exception)
        {
            _exHelper = exception;
            _barberRepository = barberRepository;
            _userRepository = userRepository;
            _service = new(_userRepository, _barberRepository);
        }

        [HttpPost]
        [Route("FireBarber")]
        public IActionResult FireBarber([FromBody] FireBarberDto dto)
        {
            try
            {
                var result = _service.Fire(dto);
                return StatusCode(result._StatusCode, result._Data == null ? new MessageDto(result._Message) : result._Data);
            }
            catch (Exception e)
            {
                var info = _exHelper.Error(e);
                return StatusCode(info._StatusCode, info);
            }
        }

        [HttpPost]
        [Route("HireBarber")]
        public IActionResult HireBarber([FromBody] HireBarberDto dto)
        {
            try
            {
                var result = _service.Hire(dto);
                return StatusCode(result._StatusCode, result._Data == null ? new MessageDto(result._Message) : result._Data);
            }
            catch (Exception e)
            {
                var info = _exHelper.Error(e);
                return StatusCode(info._StatusCode, info);
            }
        }

        [HttpPost]
        [Route("UpdateBarber")]
        public IActionResult ChangeAdress([FromBody] UpdateBarberDto dto)
        {
            try
            {
                var result = _service.Update(dto);
                return StatusCode(result._StatusCode, result._Data == null ? new MessageDto(result._Message) : result._Data);
            }
            catch (Exception e)
            {
                var info = _exHelper.Error(e);
                return StatusCode(info._StatusCode, info);
            }
        }
    }
}