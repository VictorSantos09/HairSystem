using Hair.Application.Common;

namespace Hair.Application.ApiRequest
{
    public class JokeService
    {
        private readonly IApiRequest _service;
        public string URL { get; private set; } = "https://official-joke-api.appspot.com/random_joke";

        public JokeService(IApiRequest service)
        {
            _service = service;
        }

        public BaseDto InitializeAndLoad()
        {
            var result = _service.InitializeAndLoad(URL, new JokeEntity());

            return new BaseDto(result._StatusCode, result._Data == null ? new MessageDto(result._Message) : result._Data);
        }
    }
}
