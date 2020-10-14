using Microsoft.EntityFrameworkCore;

namespace MissionLog.Models
{
  public class MissionLogContext : DbContext
  {
    

    public MissionLogContext(DbContextOptions options) : base(options) { }
  }
}