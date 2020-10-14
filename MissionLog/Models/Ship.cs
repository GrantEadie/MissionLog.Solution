using System.Collections.Generic;

namespace MissionLog.Models
{
  public class Ship
  {
    public Ship()
    {
      this.Missions = new HashSet<ShipMission>();
      this.Manifests = new HashSet<ShipManifest>();
    }
    public int ShipId { get; set; }
    public string ShipName { get; set; }
    public string ShipSpecies { get; set; }
    public VesselType ShipType { get; set; }
    public string ShipClass{ get; set; }
    public string ShipCaptain { get; set; }
    public virtual ICollection<ShipMission> Missions { get; set; }
    public virtual ICollection<ShipManifest> Manifests { get; set; }

    public enum VesselType 
    {
      Destroyer,
      Science,
      Transport, 
      Freighter,
      Gunship,
      Frigate, 
      Cruiser,
      Escort
    }
  }
}