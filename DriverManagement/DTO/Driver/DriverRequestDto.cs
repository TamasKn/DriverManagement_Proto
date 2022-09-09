namespace DriverManagement.DTO.Driver {
  public class DriverRequestDto {
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool IsActive { get; set; } = true;
    public CarAllocation AllocatedCar { get; set; }
    public int RaceNumber { get; set; }
    public DateTime JoinedAt { get; set; } = DateTime.Now;
  }
}
