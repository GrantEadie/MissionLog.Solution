using Microsoft.EntityFrameworkCore;

namespace MissionLog.Models
{
  public class MissionLogContext : DbContext
  {
    
    public virtual DbSet<Ship> Ships { get; set; }
    public virtual DbSet<Mission> Missions { get; set; }
    public virtual DbSet<Manifest> Manifests { get; set; }
    public DbSet<MissionManifest> MissionManifest { get; set; }
    public DbSet<ShipManifest> ShipManifest { get; set; }
    public DbSet<ShipMission> ShipMission { get; set; }
    public MissionLogContext(DbContextOptions options) : base(options) { }
  }
}