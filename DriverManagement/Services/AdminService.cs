using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DriverManagement.Services {
  public class AdminService : IAdminService {
    private readonly DataContext _db;
    private readonly IMapper _mapper;
    private readonly IConfiguration _secret;

    public AdminService(DataContext db, IMapper mapper, IConfiguration secret) {
      _db = db;
      _mapper = mapper;
      _secret = secret;
    }

    // Login
    public async Task<LoginObject<AdminResponseDto>> Login(AdminRequestDto request) {

      LoginObject<AdminResponseDto> response = new();

      try {

        Admin admin = _db.Admins.FirstOrDefault(a => a.Email == request.Email);

        bool verified = BCrypt.Net.BCrypt.Verify(request.Password, admin.Password);

        if (admin == null || !verified) {
          throw new Exception("Email or password not matching");
        }

        response.Token = CreateToken(admin);
        response.Admin = _mapper.Map<AdminResponseDto>(admin);

      } catch (Exception err) {
        response.Success = false;
        response.Error = err.Message;
      }

      return response;
    }


    public async Task<LoginObject<AdminResponseDto>> Register(AdminRegisterDto request) {

      LoginObject<AdminResponseDto> response = new();

      try {

        Admin admin = _mapper.Map<Admin>(request);

        bool isExist = _db.Admins.FirstOrDefault(a => a.Email == request.Email) is not null;

        // Admin exist
        if (isExist) {
          throw new Exception("E-mail already exist");
        }

        admin.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);

        _db.Admins.Add(admin);
        await _db.SaveChangesAsync();

        response.Token = CreateToken(admin);
        response.Admin = _mapper.Map<AdminResponseDto>(admin);

      } catch (Exception err) {
        response.Success = false;
        response.Error = err.Message;
      }

      return response;
    }

    private string CreateToken(Admin admin) {
      List<Claim> claims = new() {
        new Claim("Email", admin.Email!),
        new Claim(ClaimTypes.Role, "Admin")   // Add the role for the Model and store in the DB instead of hardcoded
      };

      var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_secret["JWT:SecretKey"]));
      var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

      var descriptor = new SecurityTokenDescriptor {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.UtcNow.AddDays(7),
        SigningCredentials = credentials
      };
      
      var token = new JwtSecurityTokenHandler().CreateToken(descriptor);
      var jwt = new JwtSecurityTokenHandler().WriteToken(token);
      
      return jwt;
    }

  }
}
