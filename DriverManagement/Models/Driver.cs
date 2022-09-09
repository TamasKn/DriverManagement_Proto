using System.Text.Json.Serialization;

namespace DriverManagement.Models {
  
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum CarAllocation {
    Car_1,
    Car_2,
    Reserve
  }
  
  public class Driver {
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool IsActive { get; set; }
    public CarAllocation AllocatedCar { get; set; }
    public int RaceNumber { get; set; }
    public DateTime JoinedAt { get; set; }
  }
}
