using System.ComponentModel.DataAnnotations.Schema;

namespace pet_care.Models
{
  public class Vet
  {
    public int VetId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    [ForeignKey("SpecialtyId")]
    public int SpecialtyId { get; set; }
    public virtual Specialty Specialty { get; set; }
  }
}