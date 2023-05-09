namespace pet_care.Models
{
  public class Owner
  {
    public int OwnerId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public List<Pet> Pets { get; set; }
  }

}