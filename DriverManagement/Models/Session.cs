namespace DriverManagement.Models {

  public enum SessionType {
    FP1,
		FP2,
		FP3,
		Q1,
		Q2,
		Q3,
		SPRINT,
		RACE 
  }

  public class Session {
    public int Id { get; set; }
    public RaceWeekend RaceWeekend { get; set; }
    public int DriverId { get; set; }
    public SessionType Type { get; set; }
    public int FinishPosition { get; set; }
    public string BestTime { get; set; } = String.Empty;
  }
}
