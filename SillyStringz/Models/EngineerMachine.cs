namespace Stringz.Models
{
  public class EngineerMachine
  {
    public Engineer Engineer {get; set; }
    public Machine Machine { get; set; }

    public int EngineerId { get; set; }
    public int MachineId { get; set; }

    public int EngineerMachineId {get; set;}
  }
}