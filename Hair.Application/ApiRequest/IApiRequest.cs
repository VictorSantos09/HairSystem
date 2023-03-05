namespace Hair.Application.ApiRequest
{
    public interface IApiRequest
    {
        public T InitializeAndLoad<T>(string url, T entity);
    }
}
