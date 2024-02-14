using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Stringz.Models
{
  public class StringzContext: DbContext
  {

    public DbSet<EngineerMachine> EngineerMachines { get; set; }
    public DbSet<Engineer> Engineers { get; set; }
    public DbSet<Machine> Machines { get; set; }
    


    public StringzContext(DbContextOptions<StringzContext> options) : base (options) { }

    protected override void onModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<EngineerMachine>() //PK for engineermachines
        .HasKey(em => em.EngineerMachineId);

      //many to many
      modelBuilder.Entity<EngineerMachine>() 
        .HasOne(em => em.Engineer)
        .WithMany(e => e.JoinEntities)
        .HasForeignKey(em => em.EngineerId);

      modelBuilder.Entity<EngineerMachine>()
        .HasOne(em => em.Machine)
        .WithMany(m => m.Engineers)
        .HasForeignKey(em => em.MachineId);
    }
  }
}
