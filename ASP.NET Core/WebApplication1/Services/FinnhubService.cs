using ServiceContracts;

namespace Services
{
    public class FinnhubService : IFinnhubService
    {
        /// <inheritdoc/>
        public Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
        {
            throw new NotImplementedException();
        }
    }
}
