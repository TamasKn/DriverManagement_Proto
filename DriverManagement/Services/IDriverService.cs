using DriverManagement.Services.DataObject;

namespace DriverManagement.Services {
  public interface IDriverService {
    Task<DataObject<List<DriverResponseDto>>> AllDrivers();
    Task<DataObject<List<DriverResponseDto>>> ActiveDrivers();
    Task<DataObject<DriverResponseDto>> SingleDriver(int id);
    Task<DataObject<DriverResponseDto>> NewDriver(DriverRequestDto request);
    Task<DataObject<DriverResponseDto>> UpdateDriver(int id, DriverUpdateDto request);
    Task<DataObject<DriverResponseDto>> Archive(int id);
  }
}
