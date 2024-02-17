using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Stringz.Models;

namespace Stringz.Models
{
  public class StringzContext : DbContext
  {

    public DbSet<EngineerMachine> EngineerMachines { get; set; }
    public DbSet<Engineer> Engineers { get; set; }
    public DbSet<Machine> Machines { get; set; }



    public StringzContext(DbContextOptions<StringzContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)//doing this explicitly because i was having issues with workbench
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<EngineerMachine>() //PK for engineermachines
        .HasKey(em => em.EngineerMachineId);

      //many to many
      modelBuilder.Entity<EngineerMachine>()
    .HasOne(em => em.Engineer)
    .WithMany(e => e.JoinEntities)
    .HasForeignKey(em => em.EngineerId)
    .OnDelete(DeleteBehavior.Cascade);//so that deleting an engineer doesn't break stuff

      modelBuilder.Entity<EngineerMachine>()
    .HasOne(em => em.Machine)
    .WithMany(m => m.Engineers)
    .HasForeignKey(em => em.MachineId)
    .OnDelete(DeleteBehavior.Cascade);
    }
  }
}
