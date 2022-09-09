namespace DriverManagement.Models {
  
  public enum Tyre {
    Soft,
    Medium,
    Hard,
    Intermediate,
    Wet
  }

  public class Stint {
    public int Id { get; set; }
    public int SessionId { get; set; }
    public Tyre Tyre { get; set; }
    public int IntendedLaps { get; set; }
    public int FinishedLaps { get; set; }
    public double PitStopTime { get; set; }
  }
}
