using Moq;
using FluentAssertions;

namespace stock_options.Test;

public class TestStock

{
    [Theory]
    [InlineData("GOOG", "GOOG")]
    public void HasStock(string symbol, string findStock)
    {
        List<Stock> Mockstocks()
        {
            var stockList = new List<Stock>();

            stockList.Add(new Stock("stock1", symbol, "2000", "22", "11"));

            return stockList;
        }
        var mock = Mockstocks();

        var stockServiceMock = new Mock<IStockService>();
        var stockMock = new Mock<IStock>();
        stockServiceMock.Setup(p => p.stocks()).Returns(mock);

        var stockOptionsInstance = new StockOptions(stockServiceMock.Object);
        var result = stockOptionsInstance.getStock(symbol);
        result.Should().NotBeNull();
        result.symbol.Should().Be(findStock);
    }

    [Theory]
    [InlineData("Common", "Common", 1030.00, 1000.00, 1500.00)]
    public void HasStockRecomend(string mockType, string findType, double price, double minValue, double maxValue)
    {
        List<Stock> Mockstocks()
        {
            var stockList = new List<Stock>();

            stockList.Add(new Stock("stock2", "GOOX", price.ToString(), "22", mockType));

            return stockList;
        }
        var mock = Mockstocks();

        var stockServiceMock = new Mock<IStockService>();
        var stockMock = new Mock<IStock>();
        stockServiceMock.Setup(p => p.stocks()).Returns(mock);


        var stockOptionsInstance = new StockOptions(stockServiceMock.Object);
        var result = stockOptionsInstance.recomendStock(mockType, minValue, maxValue);
        result.Should().NotBeNull();
        result.type.Should().Be(findType);
        result.lastPrice.Should().Be(price);



    }
}
