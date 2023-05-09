namespace pet_care.Repository
{
  public class BaseRepository
  {
    protected readonly PetCareContext _context;
    public BaseRepository(PetCareContext context)
    {
      _context = context;
    }

    public void Add<T>(T entity) where T : class
    {
      _context.Set<T>().Add(entity);
      _context.SaveChanges();
    }

    public void Update<T>(T entity) where T : class
    {
      _context.Set<T>().Update(entity);
      _context.SaveChanges();
    }

    public void Delete<T>(T entity) where T : class
    {
      _context.Set<T>().Remove(entity);
      _context.SaveChanges();
    }

    public void Save()
    {
      _context.SaveChanges();
    }

    public void SaveChanges()
    {
      _context.SaveChanges();
    }
  }
}