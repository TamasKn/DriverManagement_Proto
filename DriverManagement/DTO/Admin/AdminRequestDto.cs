using System.ComponentModel.DataAnnotations;

namespace DriverManagement.DTO.Admin {
  public class AdminRequestDto {
    [EmailAddress]
    public string? Email { get; set; }
    public string? Password { get; set; }
  }
}
