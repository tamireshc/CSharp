using LoggingIn.Requests;

namespace LoggingIn.Core;

public class Animal
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public Species Species { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Animal(int id, AnimalRequest request)
    {
        Id = id;
        Name = request.Name;
        Species = request.Species;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Animal() { }
}