using System.Collections.Generic;

namespace MissionLog.Models
{
  public class Mission
  {
    public Mission()
    {
      this.Ships = new HashSet<ShipMission>();
      this.Manifests = new HashSet<MissionManifest>();
    }
    public int MissionId { get; set; }
    public string MissionName { get; set; }
    public string MissionDescription { get; set; }
    public virtual ICollection<ShipMission> Ships { get; set; }
    public virtual ICollection<MissionManifest> Manifests { get; set; }
  }
}