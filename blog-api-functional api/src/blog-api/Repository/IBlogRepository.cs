

public interface IBlogRepository
{

  public void Add<T>(T entity) where T : class;

  public void Delete<T>(T entity) where T : class;

  public void Update<T>(T entity) where T : class;

  public T? Get<T>(int id) where T : class;


  public IEnumerable<T> GetAll<T>() where T : class;


}