namespace DriverManagement.Models {
  public class Admin {
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Password { get; set; }
    public DateTime JoinedAt { get; set; } = DateTime.Now;
    public DateTime? DeletedAt { get; set; } = null;
    // public string? Role { get; set; } = "Admin";
  }
}
