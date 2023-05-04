using Microsoft.EntityFrameworkCore;
using blog_api.Models;

namespace blog_api.Repository;

public class BlogContext : DbContext
{

  public DbSet<Post>? Posts { get; set; }


  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {

      var connectionString = Environment.GetEnvironmentVariable("DOTNET_CONNECTION_STRING");


      optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=master;User=SA;Password=Password12!;");
    }
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // modelBuilder.Entity<Author>()
    // .HasKey(x => x.AuthorId);

    // modelBuilder.Entity<Post>()
    // .HasKey(x => x.PostId);

    modelBuilder.Entity<Post>()
    .HasOne(c => c.Author)
    .WithMany(x => x.Posts)
    .HasForeignKey(d => d.AuthorId);
  }
}
