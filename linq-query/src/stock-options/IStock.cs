namespace stock_options;

public interface IStock
{
  public string name { get; set; }
  public string symbol { get; set; }
  public double lastPrice { get; set; }
  public string change { get; set; }
  public string type { get; set; }
}