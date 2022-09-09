
using DriverManagement.Services.DataObject;

namespace DriverManagement.Services {
  public class DriverService : IDriverService {

    private readonly DataContext _db;
    private readonly IMapper _mapper;

    public DriverService(DataContext db, IMapper mapper) {
      _db = db;
      _mapper = mapper;
    }

    // List all drivers
    public async Task<DataObject<List<DriverResponseDto>>> AllDrivers() {

      DataObject<List<DriverResponseDto>> response = new();

      try {

        List<Driver> list = _db.Drivers.ToList();
        response.Data = _mapper.Map<List<DriverResponseDto>>(list);

      } catch (Exception err) {
        response.Success = false;
        response.Error = err.Message;
      }

      return response;
    }

    // List only active drivers
    public async Task<DataObject<List<DriverResponseDto>>> ActiveDrivers() {
      List<Driver> list = _db.Drivers
        .FromSqlInterpolated($"SELECT * FROM dbo.Drivers")
        .Where(d => d.IsActive)
        .OrderBy(b => b.Id)
        .ToList();

      var response = new DataObject<List<DriverResponseDto>> {
        Data = _mapper.Map<List<DriverResponseDto>>(list)
      };
      return response;
    }

    // Get single driver by ID
    public async Task<DataObject<DriverResponseDto>> SingleDriver(int id) {

      DataObject<DriverResponseDto> response = new();

      try {
        Driver? driver = await _db.Drivers.FindAsync(id);
        DriverResponseDto data = _mapper.Map<DriverResponseDto>(driver);
        
        if (data == null) {
          throw new Exception("Driver not found");
        }

        response.Data = data;

      } catch (Exception ex) {
        response.Success = false;
        response.Error = ex.Message;
      }

      return response;
    }


    // Add new driver
    public async Task<DataObject<DriverResponseDto>> NewDriver(DriverRequestDto request) {
      _db.Drivers.Add(_mapper.Map<Driver>(request));
      await _db.SaveChangesAsync();

      var response = new DataObject<DriverResponseDto> {
        Data = _mapper.Map<DriverResponseDto>(request)
      };
      return response;
    }

    // Update driver
    public async Task<DataObject<DriverResponseDto>> UpdateDriver(int id, DriverUpdateDto request) {

      Driver? driver = await _db.Drivers.FindAsync(id);

      // Updating the necessary fields
      _mapper.Map(request, driver);

      _db.Drivers.Update(_mapper.Map<Driver>(driver));
      await _db.SaveChangesAsync();

      var response = new DataObject<DriverResponseDto> {
        Data = _mapper.Map<DriverResponseDto>(driver)
      };
      return response;
    }

    // Archive driver (set to inactive)
    public async Task<DataObject<DriverResponseDto>> Archive(int id) {
      Driver? driver = await _db.Drivers.FindAsync(id);

      if(driver is not null) {
        driver.IsActive = false;
      }
      
      _db.Drivers.Update(_mapper.Map<Driver>(driver));
      await _db.SaveChangesAsync();

      var response = new DataObject<DriverResponseDto> {
        Data = _mapper.Map<DriverResponseDto>(driver)
      };
      return response;
    }

  }
}
