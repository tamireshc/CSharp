using System.ComponentModel.DataAnnotations.Schema;

namespace pet_care.Models
{
  public class Appointment
  {
    public Appointment()
    {

    }
    [ForeignKey("VetId")]
    public int VetId { get; set; }
    public Vet? Vet { get; set; }

    [ForeignKey("PetId")]
    public int PetId { get; set; }
    public Pet? Pet { get; set; }

  }

}