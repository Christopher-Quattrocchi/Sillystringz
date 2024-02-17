using System.Collections.Generic;


namespace Stringz.Models
{
  public class Machine
  {
    public int MachineId { get; set; }
    public string Name { get; set; }
  

    public List<EngineerMachine> Engineers { get; set; }

    public Machine()
    {
      Engineers = new List<EngineerMachine>();
    }
  }
}

