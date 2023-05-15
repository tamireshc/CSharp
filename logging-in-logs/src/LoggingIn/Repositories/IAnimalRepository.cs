using LoggingIn.Core;

namespace LoggingIn.Repositories;

public interface IAnimalRepository
{
    public IEnumerable<Animal> GetAll();

    public Animal? GetById(int id);

    public bool Create(Animal animal);

    public bool Update(int id, dynamic fields);

    public bool Delete(int id);

    public int GetNextIdValue();
}