using Hair.Application.ApiRequest.Entities;
using Hair.Application.Common;
using Hair.Application.Dto;
using Hair.Application.Extensions;
using Hair.Application.Validators;

namespace Hair.Application.ApiRequest.Processor
{
    public class CepProcessor
    {
        private readonly IApiRequest _service;
        private string URL { get; set; }

        public CepProcessor(IApiRequest service)
        {
            _service = service;
        }

        private BaseDto InitializeAndLoad()
        {
            var result = _service.InitializeAndLoad(URL, new CepEntity());

            if (result.Status == 404)
            {
                return BaseDtoExtension.NotFound("CEP");
            }

            else if (result.Status != 200)
            {
                return BaseDtoExtension.Error("Não foi possível efetuar a busca do CEP");
            }

            else
            {
                var output = new BaseDto(200, result);
                return output;
            }
        }

        public BaseDto GetCep(GetCepDto dto)
        {
            if (Validation.NotEmpty(dto.Code))
                return BaseDtoExtension.Invalid("CEP inválido");

            URL = $"https://cdn.apicep.com/file/apicep/{dto.Code}.json";

            return InitializeAndLoad();
        }
    }
}