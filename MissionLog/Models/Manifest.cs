using System.Collections.Generic;

namespace MissionLog.Models
{
  public class Manifest
  {
    public Manifest()
    {
      this.Missions = new HashSet<MissionManifest>();
      this.Ships = new HashSet<ShipManifest>();
    }
    public int ManifestId { get; set; }
    public string ManifestTitle { get; set; }
    public string ManifestLifeSupportSupply { get; set; }
    public string ManifestShipCargo { get; set; }
    public string ManifestWeapon { get; set; }
    public virtual ICollection<ShipManifest> Ships { get; set; }
    public virtual ICollection<MissionManifest> Missions { get; set; }
  }
}