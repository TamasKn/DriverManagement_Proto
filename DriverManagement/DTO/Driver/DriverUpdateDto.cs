namespace DriverManagement.DTO.Driver {
  public class DriverUpdateDto {
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public CarAllocation AllocatedCar { get; set; }
    public int RaceNumber { get; set; }
  }
}
