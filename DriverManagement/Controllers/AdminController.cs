using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DriverManagement.Controllers {
  [Route("api/admin")]
  [ApiController]
  public class AdminController : ControllerBase {
    private readonly IAdminService _adminService;
    
    public AdminController(IAdminService adminService) {
      _adminService = adminService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AdminResponseDto>> Login(AdminRequestDto request) {
      return Ok(await _adminService.Login(request));
    }

    [HttpPost("register")]
    public async Task<ActionResult<AdminResponseDto>> Register(AdminRegisterDto request) {
      return Ok(await _adminService.Register(request));
    }

  }
}
