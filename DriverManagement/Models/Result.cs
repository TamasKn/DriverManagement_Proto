namespace DriverManagement.Models {
  
  public enum RaceWeekend {
    Bahrain,
    Jeddah,
    Melbourne
  }
  
  public class Result {
    public int Id { get; set; }
    public int DriverId { get; set; }
    public RaceWeekend RaceWeekend { get; set; }
    public DateTime Date { get; set; }
    public double Points { get; set; }
    public bool IsFastestLap { get; set; }
  }
}
