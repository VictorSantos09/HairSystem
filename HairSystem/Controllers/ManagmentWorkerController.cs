using FluentValidation;
using Hair.Application.Common;
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
        private readonly IException _exHelper;

        public ManagmentWorkerController(IException exception, IBaseRepository<UserEntity> userRepository,
            IBaseRepository<WorkerEntity> workerRepository, IValidator<WorkerEntity> workerValidator)
        {
            _exHelper = exception;
            _service = new(userRepository, workerRepository, workerValidator);
        }

        [HttpDelete]
        [Route("FireBarber")]
        public IActionResult FireBarber([FromBody] FireWorkerDto dto)
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
        public IActionResult HireBarber([FromBody] HireWorkerDto dto)
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

        [HttpPut]
        [Route("UpdateBarber")]
        public IActionResult ChangeAdress([FromBody] UpdateWorkerDto dto)
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