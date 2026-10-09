using StocksApp.ServiceContracts;
using System.Text.Json;
namespace StocksApp.Services
{
    public class FinnhubService : IFinnhubService
    {
        readonly IHttpClientFactory _httpClientFactory;
        readonly IConfiguration _configuration;
        public FinnhubService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol)
        {
            using var httpClient = this._httpClientFactory.CreateClient();
            var httpRequestMessage = new HttpRequestMessage()
            {
                RequestUri = new($"https://finnhub.io/api/v1/stock/profile2?symbol={stockSymbol}&token={this._configuration["FinnhubToken"]}"),
                Method = HttpMethod.Get,
            };

            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            var stream = httpResponseMessage.Content.ReadAsStream();

            var response = new StreamReader(stream).ReadToEnd();
            var responseDict = JsonSerializer.Deserialize<Dictionary<string, object>>(response) ?? throw new InvalidOperationException("No response from finnhub server");
            if (responseDict.TryGetValue("error", out object? value))
            {
                throw new InvalidOperationException(Convert.ToString(value));
            }

            return responseDict;
        }

        public async Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
        {
            using var httpClient = this._httpClientFactory.CreateClient();
            var httpRequestMessage = new HttpRequestMessage()
            {
                RequestUri = new($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={this._configuration["FinnhubToken"]}"),
                Method = HttpMethod.Get,
            };

            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            var stream = httpResponseMessage.Content.ReadAsStream();

            var response = new StreamReader(stream).ReadToEnd();
            var responseDict = JsonSerializer.Deserialize<Dictionary<string, object>>(response) ?? throw new InvalidOperationException("No response from finnhub server");
            if (responseDict.TryGetValue("error", out object? value))
            {
                throw new InvalidOperationException(Convert.ToString(value));
            }

            return responseDict;
        }
    }
}
