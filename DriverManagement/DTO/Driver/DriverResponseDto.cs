namespace DriverManagement.DTO.Driver {
  public class DriverResponseDto {
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int Age {
      get {
        int age = (int)((DateTime.Now - DateOfBirth).TotalDays / 365.242199);
        return age;
      }
    }
    public bool IsActive { get; set; }
    public CarAllocation AllocatedCar { get; set; }
    public int RaceNumber { get; set; }
    public DateTime JoinedAt { get; set; }
  }
}
