using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StocksApp.Models;
using StocksApp.Services;

namespace StocksApp.Controllers
{
    public class HomeController : Controller
    {
        readonly FinnhubService _finnhubService;
        //readonly IConfiguration _configuration;
        readonly IOptions<TradingOptions> _tradingOptions;
        public HomeController(FinnhubService finnhubService, IOptions<TradingOptions> tradingOptions)//IConfiguration configuration)
        {
            _finnhubService = finnhubService;
            //_configuration = configuration;
            _tradingOptions = tradingOptions;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            if (_tradingOptions.Value.DefaultStockSymbol == null)
            {
                _tradingOptions.Value.DefaultStockSymbol = "MSFT";
            }

            var responseDict = await _finnhubService.GetStockPriceQuote(_tradingOptions.Value.DefaultStockSymbol);
            var stock = new Stock()
            {
                StockSymbol = this._tradingOptions.Value.DefaultStockSymbol,
                CurrentPrice = Convert.ToDouble(responseDict["c"].ToString()),
                HighestPrice = Convert.ToDouble(responseDict["h"].ToString()),
                LowestPrice = Convert.ToDouble(responseDict["l"].ToString()),
                OpenPrice = Convert.ToDouble(responseDict["o"].ToString()),
            };

            return this.View(stock);
        }
    }
}
