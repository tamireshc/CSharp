using JsonFlatFileDataStore;
using LoggingIn.Core;

namespace LoggingIn.Repositories;

public class AnimalRepository : IAnimalRepository
{
    private readonly IDataStore _db;

    public AnimalRepository(IDataStore db)
    {
        _db = db;
    }

    public IEnumerable<Animal> GetAll() => GetCollection().AsQueryable();

    public Animal? GetById(int id) => GetCollection().Find(r => r.Id == id).FirstOrDefault();

    public bool Create(Animal animal) => GetCollection().InsertOne(animal);

    public bool Update(int id, dynamic fields) => GetCollection().UpdateOne(id, fields);

    public bool Delete(int id) => GetCollection().DeleteOne(id);

    public int GetNextIdValue() => GetCollection().GetNextIdValue();

    private IDocumentCollection<Animal> GetCollection() =>
        _db.GetCollection<Animal>();
}