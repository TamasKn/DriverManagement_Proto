namespace DriverManagement {
  public class DriverProfile : Profile {
    public DriverProfile() {
      CreateMap<Driver, DriverResponseDto>();
      CreateMap<DriverRequestDto, Driver>();
      CreateMap<DriverRequestDto, DriverResponseDto>();
      CreateMap<DriverResponseDto, DriverRequestDto>();
      CreateMap<DriverUpdateDto, Driver>();
    }
  }
}
