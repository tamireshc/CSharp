using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blog_api.Models;
public class Author
{
  [Key]
  public int AuthorId { get; set; }
  public string Name { get; set; } = default!;
  public string Email { get; set; } = default!;
  public string About { get; set; } = default!;
  [InverseProperty("Author")]
  public virtual ICollection<Post>? Posts { get; set; }
}