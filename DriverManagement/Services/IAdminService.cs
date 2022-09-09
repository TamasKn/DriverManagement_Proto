namespace DriverManagement.Services {
  public interface IAdminService {
    Task<LoginObject<AdminResponseDto>> Login(AdminRequestDto request);
    Task<LoginObject<AdminResponseDto>> Register(AdminRegisterDto request);
  }
}
