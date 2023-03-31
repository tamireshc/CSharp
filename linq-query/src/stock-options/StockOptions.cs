namespace stock_options;

using System.Linq;
public class StockOptions
{
    private IStockService stockOptions;
    public StockOptions(IStockService stocks)
    {
        this.stockOptions = stocks;

    }

    /// <summary>
    /// This function find the best stock option for the given stock
    /// </summary>
    /// <param name="symbol"> A string to be find</param>
    /// <returns>A stock</returns>
    public IStock? getStock(string symbol)
    {
        var stockOptionsServiceReturn = stockOptions.stocks();
        var resultSearch = from stock in stockOptionsServiceReturn
                           where stock.symbol == symbol
                           select stock;

        var stockResult = new List<Stock>();

        foreach (var result in resultSearch)
        {
            var stockx = new Stock(result.name, result.symbol, result.lastPrice.ToString(), result.change, result.type);
            stockResult.Add(stockx);
        }
        if (stockResult.Count > 0) return stockResult[0];
        return null;
    }

    /// <summary>
    /// This function find the best stock option for the price range given
    /// </summary>
    /// <param name="type"> A string to be find</param>
    /// <param name="minPrice"> A double to be find</param>
    /// /// <param name="maxPrice"> A double to be find</param>
    /// <returns>A stock</returns>

    public IStock? recomendStock(string type, double minPrice, double maxPrice)
    {
        var stockOptionsServiceReturn = stockOptions.stocks();
        var resultSearch = from stock in stockOptionsServiceReturn
                           where stock.type == type && stock.lastPrice > minPrice && stock.lastPrice <= maxPrice
                           //  where stock.lastPrice > minPrice
                           //  where stock.lastPrice < maxPrice
                           select stock;

        var stockResult = new List<Stock>();


        foreach (var result in resultSearch)
        {
            var stockx = new Stock(result.name, result.symbol, result.lastPrice.ToString(), result.change, result.type);
            stockResult.Add(stockx);
        }

        if (stockResult.Count > 0) return stockResult[0];
        return null;


    }
}
