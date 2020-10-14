namespace MissionLog.Models
{
  public class ShipMission
  {
    public int ShipMissionId { get; set; }
    public int ShipId { get; set; }
    public int MissionId { get; set; }
    public Ship Ship { get; set; }
    public Mission Mission { get; set; }
  }
}