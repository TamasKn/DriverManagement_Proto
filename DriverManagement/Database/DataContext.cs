using Microsoft.EntityFrameworkCore;
using DriverManagement.Models;

namespace DriverManagement.Database {
  public class DataContext : DbContext {

    public DataContext() {}
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public virtual DbSet<Driver> Drivers { get; set; } = null!;
    public virtual DbSet<Result> Results { get; set; } = null!;
    public virtual DbSet<Session> Sessions { get; set; } = null!;
    public virtual DbSet<Stint> Stints { get; set; } = null!;
    public virtual DbSet<Admin> Admins { get; set; } = null!;
  }
}
