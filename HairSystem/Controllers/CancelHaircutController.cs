using Hair.Application.Dto;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class CancelHaircutController : ControllerBase
    {
        private readonly CancelHaircutService _service;

        public CancelHaircutController(IBaseRepository<UserEntity> baseRepository)
        {
            _service = new(baseRepository);
        }

        [HttpPost]
        [Route("CancelExistentHaircut")]
        public IActionResult Cancel(CancelHaircutDto dto)
        {
            var result = _service.Cancel(dto);

            return StatusCode(result._StatusCode, result._Message);
        }
    }
}
