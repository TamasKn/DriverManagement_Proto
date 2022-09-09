namespace DriverManagement.Services.LoginObject {
  public class LoginObject<T> {
    public bool Success { get; set; } = true;
    public string? Token { get; set; } = null;
    public T? Admin { get; set; }
    public string? Error { get; set; } = null;
  }
}
