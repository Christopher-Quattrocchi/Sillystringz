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