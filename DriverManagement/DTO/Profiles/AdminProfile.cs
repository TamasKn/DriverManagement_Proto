namespace DriverManagement {
  public class AdminProfile : Profile {
    public AdminProfile() {
      CreateMap<Admin, AdminResponseDto>();
      CreateMap<AdminRegisterDto, Admin>();
    }
  }
}
