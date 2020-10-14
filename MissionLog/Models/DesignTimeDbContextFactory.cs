using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MissionLog.Models
{
  public class MissionLogContextFactory : IDesignTimeDbContextFactory<MissionLogContext>
  {
    MissionLogContext IDesignTimeDbContextFactory<MissionLogContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

      var builder = new DbContextOptionsBuilder<MissionLogContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new MissionLogContext(builder.Options);
    }
  }
}