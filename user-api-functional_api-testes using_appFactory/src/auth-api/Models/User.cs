using System.ComponentModel.DataAnnotations;

namespace auth_api.Models
{
  public class User
  {
    [Key]
    public int UserId { get; set; }
    public string FullName { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Email { get; set; } = default!;

  }
}