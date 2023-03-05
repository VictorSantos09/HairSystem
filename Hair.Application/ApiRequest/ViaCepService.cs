using Hair.Application.Common;

namespace Hair.Application.ApiRequest
{
    public class ViaCepService
    {
        private readonly IApiRequest _service;
        public string URL { get; private set; } = "https://cdn.apicep.com/file/apicep/89010-025.json";

        public ViaCepService(IApiRequest service)
        {
            _service = service;
        }

        public BaseDto InitializeAndLoad()
        {
            var result = _service.InitializeAndLoad(URL, new ViaCepEntity());

            return new BaseDto(result._StatusCode, result._Data == null ? new MessageDto(result._Message) : result._Data);
        }
    }
}
