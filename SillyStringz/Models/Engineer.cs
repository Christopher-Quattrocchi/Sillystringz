using System.Collections.Generic;


namespace Stringz.Models
{
  public class Engineer
  {
    public string Name { get; set; }
    public int EngineerId { get; set; }

    public List<EngineerMachine> JoinEntities {get; set; }

    public Engineer()
    {
      JoinEntities = new List<EngineerMachine>();
    }
  }
}