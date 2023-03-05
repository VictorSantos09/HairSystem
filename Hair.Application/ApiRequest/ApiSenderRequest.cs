using Hair.Application.Common;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using static Hair.Application.ApiRequest.ApiHelper;

namespace Hair.Application.ApiRequest
{
    internal class ApiSenderRequest : IApiRequest
    {
        public void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<T> LoadContent<T>(string url, T entity)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            using (HttpResponseMessage response = await ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    entity = await response.Content.ReadFromJsonAsync<T>();

                    return entity;

                }

                throw new Exception(response.ReasonPhrase);
            }
        }
        public BaseDto InitializeAndLoad<T>(string url, T entity)
        {
            InitializeClient();
            var result = LoadContent(url, entity);

            return new BaseDto(200, result.GetAwaiter().GetResult());
        }
    }
}
