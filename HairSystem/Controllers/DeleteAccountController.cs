using Hair.Application.Dto;
using Hair.Application.Services;
using Hair.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class DeleteAccountController : ControllerBase
    {
        private readonly DeleteAccountService _service;

        public DeleteAccountController(IGetByEmail getByEmail)
        {
            _service = new(getByEmail);
        }

        [HttpPost]
        [Route("DeleteAccount")]
        public IActionResult Delete([FromBody] DeleteAccountDto dto)
        {
            var result = _service.Delete(dto);

            return StatusCode(result._StatusCode, result._Message);
        }
    }
}