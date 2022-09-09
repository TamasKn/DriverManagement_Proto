namespace DriverManagement.DTO.Admin {
  public class AdminResponseDto {
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public DateTime JoinedAt { get; set; } = DateTime.Now;
  }
}
