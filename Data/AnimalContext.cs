using AnimalApiCSharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace AnimalApiCSharp.Data
{
  public class AnimalContext : DbContext
  {
    public AnimalContext(DbContextOptions<AnimalContext> options) : base(options)
    {
    }

    public DbSet<Animal> Animals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      var tableModel = modelBuilder.Entity<Animal>();

      tableModel.ToTable("animals");
      tableModel.HasKey(x => x.Id);
      tableModel.Property(x => x.Id).HasValueGenerator<GuidValueGenerator>();
      tableModel.Property(x => x.Id).HasColumnName("id");
      tableModel.Property(x => x.CommonName).HasColumnName("common_name").IsRequired();
      tableModel.Property(x => x.GenericName).HasColumnName("generic_name");
      tableModel.Property(x => x.SpeciesName).HasColumnName("species_name");
      tableModel.Property(x => x.SubspeciesName).HasColumnName("subspecies_name");
    }
  }
}