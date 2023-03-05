using Hair.Application.Common;
using Hair.Application.Dto;

namespace Hair.Application.ApiRequest
{
    public class CepService
    {
        private readonly IApiRequest _service;
        private string URL { get; set; }

        public CepService(IApiRequest service)
        {
            _service = service;
        }

        private BaseDto InitializeAndLoad()
        {
            var result = _service.InitializeAndLoad(URL, new CepEntity());

            return new BaseDto(result._StatusCode, result._Data == null ? new MessageDto(result._Message) : result._Data);
        }

        public BaseDto GetCep(GetCepDto dto)
        {
            URL = $"https://cdn.apicep.com/file/apicep/{dto.Code}.json";

            return InitializeAndLoad();
        }
    }
}