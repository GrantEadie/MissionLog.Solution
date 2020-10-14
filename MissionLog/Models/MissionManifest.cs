namespace MissionLog.Models
{
  public class MissionManifest
  {
    public int MissionManifestId { get; set; }
    public int MissionId { get; set; }
    public int ManifestId { get; set; }
    public Manifest Manifest { get; set; }
    public Mission Mission { get; set; }
  }
}