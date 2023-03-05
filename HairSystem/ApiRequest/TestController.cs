using Hair.Application.ApiRequest;
using Microsoft.AspNetCore.Mvc;

namespace HairSystem.ApiRequest
{
    [ApiController]
    [Route("/teste")]
    public class TestController : ControllerBase
    {
        private readonly JokeService service;
        private readonly ViaCepService service2;

        public TestController(IApiRequest baseRequest)
        {
            service = new JokeService(baseRequest);
            service2 = new ViaCepService(baseRequest);
        }

        [HttpGet]
        [Route("joke")]
        public ActionResult Index()
        {
            var result = service.InitializeAndLoad();

            return StatusCode(result._StatusCode, result._Data == null ? result._Message : result._Data);
        }

        [HttpGet]
        [Route("viacep")]
        public ActionResult Get()
        {
            var result = service2.InitializeAndLoad();

            return StatusCode(result._StatusCode, result._Data == null ? result._Message : result._Data);
        }
    }
}
