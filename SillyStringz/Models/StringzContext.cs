using Microsoft.EntityFrameworkCore;

namespace Stringz.Models
{
  public class StringzContext: DbContext
  {

    public DbSet<EngineerMachine> EngineerMachines { get; set; }
    public DbSet<Engineer> Engineers { get; set; }
    public DbSet<Machine> Machines { get; set; }
    


    public FactoryContext(DbContextOptions options) : base (options) { }
  }
}


//confusing chatgpt code below for reference
// using Microsoft.EntityFrameworkCore;

// namespace Factory.Models
// {
//     public class FactoryContext : DbContext
//     {
//         public FactoryContext(DbContextOptions<FactoryContext> options) : base(options) {}

//         protected override void OnModelCreating(ModelBuilder builder)
//         {
//             builder.Entity<MachineEngineer>()
//                 .HasKey(me => new { me.EngineerId, me.MachineId });

//             builder.Entity<MachineEngineer>()
//                 .HasOne(me => me.Engineer)
//                 .WithMany(e => e.Machines)
//                 .HasForeignKey(me => me.EngineerId);

//             builder.Entity<MachineEngineer>()
//                 .HasOne(me => me.Machine)
//                 .WithMany(m => m.Engineers)
//                 .HasForeignKey(me => me.MachineId);
//         }

//         public DbSet<Engineer> Engineers { get; set; }
//         public DbSet<Machine> Machines { get; set; }
//         public DbSet<MachineEngineer> MachineEngineers { get; set; }
//     }
// }