using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StocksApp.Models;
using StocksApp.Services;

namespace StocksApp.Controllers
{
    public class TradeController : Controller
    {
        readonly FinnhubService _finnhubService;
        readonly IOptions<TradingOptions> _tradingOptions;
        public TradeController(FinnhubService finnhubService, IOptions<TradingOptions> tradingOptions)
        {
            this._finnhubService = finnhubService;
            this._tradingOptions = tradingOptions;
        }

        [Route("/trade")]
        public async Task<IActionResult> Index()
        {
            if (this._tradingOptions.Value.DefaultStockSymbol == null)
            {
                this._tradingOptions.Value.DefaultStockSymbol = "MSFT";
            }

            var responseDict = await this._finnhubService.GetCompanyProfile(this._tradingOptions.Value.DefaultStockSymbol);
            var stockTrade = new StockTrade()
            {
                StockSymbol = this._tradingOptions.Value.DefaultStockSymbol,
                StockName = responseDict?["name"].ToString(),
                //Price = Convert.ToDouble(responseDict?["h"].ToString()),
                //Quantity = Convert.ToInt(responseDict?["l"].ToString()),
            };
            responseDict = await _finnhubService.GetStockPriceQuote(_tradingOptions.Value.DefaultStockSymbol);
            stockTrade.Price = Convert.ToDouble(responseDict?["o"].ToString());
            return this.View(stockTrade);
        }
    }
}
