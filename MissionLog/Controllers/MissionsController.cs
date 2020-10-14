using Microsoft.AspNetCore.Mvc;
using MissionLog.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace MissionLog.Controllers
{
  public class MissionsController : Controller
  {
    private readonly MissionLogContext _db;

    public MissionsController(MissionLogContext db)
    {
      _db = db ;
    }

    public ActionResult Index()
    {
      List<Mission> model = _db.Missions.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Mission mission)
    {
      _db.Missions.Add(mission);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }  
    public ActionResult Details(int id)
    {
      var thisMission = _db.Missions
        .Include(mission => mission.Ships)
        .ThenInclude(join => join.Ship)
        .Include(mission => mission.Manifests)
        .ThenInclude(join => join.Manifest)
        .FirstOrDefault(mission => mission.MissionId == id);
      return View(thisMission);
    }
    public ActionResult Edit(int id)
    {
      var thisMission = _db.Missions.FirstOrDefault(missions => missions.MissionId == id);
      ViewBag.ShipId = new SelectList(_db.Ships, "ShipId", "ShipName");
      return View(thisMission);
    }

    [HttpPost]
    public ActionResult Edit(Mission mission)
    {
      _db.Entry(mission).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = mission.MissionId });
    }
    public ActionResult Delete(int id)
    {
      var thisMission = _db.Missions.FirstOrDefault(missions => missions.MissionId == id);
      return View(thisMission);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMission = _db.Missions.FirstOrDefault(missions => missions.MissionId == id);
      _db.Missions.Remove(thisMission);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult DeleteShip(int joinId, int missionId)
    {
      var joinEntry = _db.ShipMission.FirstOrDefault(entry => entry.ShipMissionId == joinId);
      _db.ShipMission.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = missionId});
    }
    public ActionResult AddShip(int id)
    {
      var thisMission = _db.Missions.FirstOrDefault(missions => missions.MissionId == id);
      ViewBag.ShipId = new SelectList(_db.Ships, "ShipId", "ShipName");
      return View(thisMission);
    }
    [HttpPost]
    public ActionResult AddShip(Mission mission, int ShipId)
    {
      if (ShipId != 0)
      {
      _db.ShipMission.Add(new ShipMission() { ShipId = ShipId, MissionId = mission.MissionId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = mission.MissionId});
    }
    

    [HttpPost]
    public ActionResult DeleteManifest(int joinId, int missionId)
    {
      var joinEntry = _db.MissionManifest.FirstOrDefault(entry => entry.MissionManifestId == joinId);
      _db.MissionManifest.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = missionId});
    }
    public ActionResult AddManifest(int id)
    {
      var thisMission = _db.Missions.FirstOrDefault(missions => missions.MissionId == id);
      ViewBag.ManifestId = new SelectList(_db.Manifests, "ManifestId", "ManifestName");
      return View(thisMission);
    }
    [HttpPost]
    public ActionResult AddManifest(Mission mission, int ManifestId)
    {
      if (ManifestId != 0)
      {
      _db.MissionManifest.Add(new MissionManifest() { ManifestId = ManifestId, MissionId = mission.MissionId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = mission.MissionId});
    }
  }
}