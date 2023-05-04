
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blog_api.Models;
public class Post
{
  [Key]
  public int PostId { get; set; }
  public string Title { get; set; } = default!;
  public string Content { get; set; } = default!;
  [ForeignKey("AuthorId")]
  public int AuthorId { get; set; }
  public virtual Author? Author { get; set; }

}