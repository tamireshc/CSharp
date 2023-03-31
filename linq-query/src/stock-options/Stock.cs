namespace stock_options;
public class Stock : IStock
{
  public string name { get; set; }
  public string symbol { get; set; }
  public double lastPrice { get; set; }
  public string change { get; set; }
  public string type { get; set; }

  public Stock(string name, string symbol, string lastPrice, string change, string type)
  {
    this.name = name;
    this.symbol = symbol;
    this.lastPrice = double.Parse(lastPrice);
    this.change = change;
    this.type = type;
  }
}
