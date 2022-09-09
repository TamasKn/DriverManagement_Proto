using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DriverManagement.Controllers {
  [Route("api/driver")]
  [ApiController]
  [Authorize(Roles = "Admin")]

  public class DriverController : ControllerBase {

    private readonly IDriverService _driverService;

    public DriverController(IDriverService driverService) {
      _driverService = driverService;
    }

    [HttpGet]
    public async Task<ActionResult<List<DriverResponseDto>>> Get() {
      return Ok(await _driverService.ActiveDrivers());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DriverResponseDto>> GetSingle(int id) {
      return Ok(await _driverService.SingleDriver(id));
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<DriverResponseDto>>> AllDrivers() {
      return Ok(await _driverService.AllDrivers());
    }

    [HttpPost]
    public async Task<ActionResult<DriverResponseDto>> Add(DriverRequestDto request) {
      await _driverService.NewDriver(request);
      return Ok(request);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<DriverResponseDto>> Update(int id, DriverUpdateDto request) {
      return Ok(await _driverService.UpdateDriver(id, request));
    }

    [HttpPut("archive/{id}")]
    public async Task<ActionResult<DriverResponseDto>> Archive(int id) {
      return Ok(await _driverService.Archive(id));
    }
  }
}
