namespace MissionLog.Models
{
  public class ShipManifest
  {
    public int ShipManifestId { get; set; }
    public int ManifestId { get; set; }
    public int ShipId { get; set; }
    public Manifest Manifest { get; set; }
    public Ship Ship { get; set; }
  }
}