using Microsoft.EntityFrameworkCore;
using pet_care.Models;

namespace pet_care.Repository;

public class PetCareContext : DbContext
{
  public DbSet<Appointment>? Appointments { get; set; }
  public DbSet<Breed> Breeds { get; set; }
  public DbSet<Owner> Owners { get; set; }
  public DbSet<Pet>? Pets { get; set; }
  public DbSet<Specialty> Specialtys { get; set; }
  public DbSet<Vet>? Vets { get; set; }
  public PetCareContext()
  {
  }

  public PetCareContext(DbContextOptions<PetCareContext> options)
     : base(options)
  {
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=PetCare;User=SA;Password=Password12!;");
    }
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Vet>()
        .HasOne(b => b.Specialty);

    modelBuilder.Entity<Pet>()
        .HasOne(b => b.Breed);

    modelBuilder.Entity<Owner>()
      .HasMany(b => b.Pets);


    modelBuilder.Entity<Appointment>()
      .HasKey(appointment => new { appointment.PetId, appointment.VetId });

  }
}

