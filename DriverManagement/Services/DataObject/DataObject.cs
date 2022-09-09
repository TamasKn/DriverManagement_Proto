namespace DriverManagement.Services.DataObject {
  public class DataObject<T> {
    public bool Success { get; set; } = true;
    public T? Data { get; set; }
    public string? Error { get; set; } = null;
  }
}
