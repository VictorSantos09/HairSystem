using System.Net;
using System.Net.Http.Headers;

namespace Hair.Application.ApiRequest
{
    /// <summary>
    /// Classe para efetuação de envio de requisições para APIs
    /// 
    /// <para>Implementa <see cref="IApiRequest"/></para>
    /// 
    /// </summary>
    public class ApiHelper : IApiRequest
    {
        public static HttpClient ApiClient { get; set; }

        private void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async Task<T> LoadContent<T>(string url, T entity)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            using (HttpResponseMessage response = await ApiClient.GetAsync(url))
            {
                entity = await response.Content.ReadAsAsync<T>();

            }

            return entity;
        }

        public T InitializeAndLoad<T>(string url, T entity)
        {
            InitializeClient();
            var result = LoadContent(url, entity);

            return result.GetAwaiter().GetResult();
        }
    }
}
