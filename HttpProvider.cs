using System.Net.Http;
using System.Threading.Tasks;

namespace QueueIT.SelfService.BusinessLogic.Economic
{
    public interface IHttpClientProvider
    {
        Task<HttpResponseMessage> GetAsync(string requestUri);
    }

    public class HttpClientProvider : IHttpClientProvider
    {
        private readonly HttpClient _httpClient;

        public HttpClientProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return _httpClient.GetAsync(requestUri);
        }
    }
}
