using System.Threading;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.HttpClient
{
    public interface IMerchHttpClient
    {
        Task<string> RequestMerch(CancellationToken token);
        Task<string> GetMerchRetrieveInfo(long retrieverId, CancellationToken token);
    }

    public class MerchHttpClient : IMerchHttpClient
    {
        private readonly System.Net.Http.HttpClient _httpClient;

        public MerchHttpClient(System.Net.Http.HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> RequestMerch(CancellationToken token)
        {
            using var response = await _httpClient.GetAsync("v1/api/merch/request", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return body;
        }

        public async Task<string> GetMerchRetrieveInfo(long retrieverId, CancellationToken token)
        {
            using var response = await _httpClient.GetAsync($"v1/api/merch/get-retrieve-info/{retrieverId}", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return body;
        }
    }
}