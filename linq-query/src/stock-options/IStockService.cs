namespace stock_options;

public interface IStockService
{
  IEnumerable<IStock> stocks();

}