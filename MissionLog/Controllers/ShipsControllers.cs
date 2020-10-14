using Microsoft.AspNetCore.Mvc;
using MissionLog.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace MissionLog.Controllers
{
  public class ShipsController : Controller
  {
    private readonly MissionLogContext _db;

    public ShipsController(MissionLogContext db)
    {
      _db = db ;
    }

    public ActionResult Index()
    {
      List<Ship> model = _db.Ships.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Ship ship)
    {
      _db.Ships.Add(ship);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }  
    public ActionResult Details(int id)
    {
      var thisShip = _db.Ships
        .Include(ship => ship.Manifests)
        .ThenInclude(join => join.Manifest)
        .Include(ship => ship.Missions)
        .ThenInclude(join => join.Mission)
        .FirstOrDefault(ship => ship.ShipId == id);
      return View(thisShip);
    }
    public ActionResult Edit(int id)
    {
      var thisShip = _db.Ships.FirstOrDefault(ships => ships.ShipId == id);
      ViewBag.ManifestId = new SelectList(_db.Manifests, "ManifestId", "ManifestName");
      return View(thisShip);
    }

    [HttpPost]
    public ActionResult Edit(Ship ship)
    {
      _db.Entry(ship).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = ship.ShipId });
    }
    public ActionResult Delete(int id)
    {
      var thisShip = _db.Ships.FirstOrDefault(ships => ships.ShipId == id);
      return View(thisShip);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisShip = _db.Ships.FirstOrDefault(ships => ships.ShipId == id);
      _db.Ships.Remove(thisShip);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult DeleteManifest(int shipId, int joinId)
    {
      var joinEntry = _db.ShipManifest.FirstOrDefault(entry => entry.ShipManifestId == joinId);
      _db.ShipManifest.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = shipId});
    }
    public ActionResult AddManifest(int id)
    {
      var thisShip = _db.Ships.FirstOrDefault(ships => ships.ShipId == id);
      ViewBag.ManifestId = new SelectList(_db.Manifests, "ManifestId", "ManifestTitle");
      return View(thisShip);
    }
    [HttpPost]
    public ActionResult AddManifest(Ship ship, int ManifestId)
    {
      if (ManifestId != 0)
      {
      _db.ShipManifest.Add(new ShipManifest() { ManifestId = ManifestId, ShipId = ship.ShipId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = ship.ShipId});
    }
    [HttpPost]
    public ActionResult DeleteMission(int shipId, int joinId)
    {
      var joinEntry = _db.ShipMission.FirstOrDefault(entry => entry.ShipMissionId == joinId);
      _db.ShipMission.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = shipId});
    }
    public ActionResult AddMission(int id)
    {
      var thisShip = _db.Ships.FirstOrDefault(ships => ships.ShipId == id);
      ViewBag.MissionId = new SelectList(_db.Missions, "MissionId", "MissionName");
      return View(thisShip);
    }
    [HttpPost]
    public ActionResult AddMission(Ship ship, int MissionId)
    {
      if (MissionId != 0)
      {
      _db.ShipMission.Add(new ShipMission() { MissionId = MissionId, ShipId = ship.ShipId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = ship.ShipId});
    }
  }
}