namespace pet_care.Models
{
  public class Pet
  {
    public int PetId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Age { get; set; }
    public int BreedId { get; set; }
    public virtual Breed Breed { get; set; }
  }
}