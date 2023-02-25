using Hair.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class TestController : ControllerBase
    {
        private readonly HaircutRepository _haircutRepository;
        private readonly UserRepository _repo;

        public TestController()
        {
            _haircutRepository = new();
            _repo = new(_haircutRepository);
        }

        [HttpPost]
        [Route("Aqui")]
        public IActionResult Get([FromBody] Dto dto)
        {
            return Ok(_repo.GetById(dto.Id));
        }

        [HttpPost]
        [Route("RemoveAlguem")]
        public IActionResult Remove([FromBody] Dto dto)
        {
            _repo.Remove(dto.Id);
            return Ok();
        }


        [HttpGet]
        [Route("GetAllTests")]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetAll());
        }
    }

    public class Dto
    {
        public Guid Id { get; set; }
    }
}
