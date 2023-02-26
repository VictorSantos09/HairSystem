using Hair.Application.Dto;
using Hair.Application.Services;
using Hair.Domain.Entities;
using Hair.Domain.Interfaces;
using Hair.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class CancelHaircutController : ControllerBase
    {
        private readonly CancelHaircutService _service;

        public CancelHaircutController(IBaseRepository<IUser> baseRepository, IBaseRepository<IHaircut> haircutRepository)
        {
            _service = new(baseRepository, haircutRepository);
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
