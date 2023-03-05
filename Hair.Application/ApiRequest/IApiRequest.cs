using Hair.Application.Common;

namespace Hair.Application.ApiRequest
{
    public interface IApiRequest
    {
        public void InitializeClient();
        public Task<T> LoadContent<T>(string url, T _entity);
        public BaseDto InitializeAndLoad<T>(string url, T _entity);
    }
}
