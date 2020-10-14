using Microsoft.AspNetCore.Mvc;
using MissionLog.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace MissionLog.Controllers
{
  public class ManifestsController : Controller
  {
    private readonly MissionLogContext _db;

    public ManifestsController(MissionLogContext db)
    {
      _db = db ;
    }

    public ActionResult Index()
    {
      List<Manifest> model = _db.Manifests.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Manifest manifest)
    {
      _db.Manifests.Add(manifest);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }  
    public ActionResult Details(int id)
    {
      var thisManifest = _db.Manifests
        .Include(manifest => manifest.Ships)
        .ThenInclude(join => join.Ship)
        .Include(manifest => manifest.Missions)
        .ThenInclude(join => join.Mission)
        .FirstOrDefault(manifest => manifest.ManifestId == id);
      return View(thisManifest);
    }
    public ActionResult Edit(int id)
    {
      var thisManifest = _db.Manifests.FirstOrDefault(manifests => manifests.ManifestId == id);
      ViewBag.ShipId = new SelectList(_db.Ships, "ShipId", "ShipName");
      return View(thisManifest);
    }

    [HttpPost]
    public ActionResult Edit(Manifest manifest)
    {
      _db.Entry(manifest).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = manifest.ManifestId });
    }
    public ActionResult Delete(int id)
    {
      var thisManifest = _db.Manifests.FirstOrDefault(manifests => manifests.ManifestId == id);
      return View(thisManifest);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisManifest = _db.Manifests.FirstOrDefault(manifests => manifests.ManifestId == id);
      _db.Manifests.Remove(thisManifest);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult DeleteShip(int manifestId, int joinId)
    {
      var joinEntry = _db.ShipManifest.FirstOrDefault(entry => entry.ShipManifestId == joinId);
      _db.ShipManifest.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = manifestId});
    }
    public ActionResult AddShip(int id)
    {
      var thisManifest = _db.Manifests.FirstOrDefault(manifests => manifests.ManifestId == id);
      ViewBag.ShipId = new SelectList(_db.Ships, "ShipId", "ShipName");
      return View(thisManifest);
    }
    [HttpPost]
    public ActionResult AddShip(Manifest manifest, int ShipId)
    {
      if (ShipId != 0)
      {
      _db.ShipManifest.Add(new ShipManifest() { ShipId = ShipId, ManifestId = manifest.ManifestId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = manifest.ManifestId});
    }
    [HttpPost]
    public ActionResult DeleteMission(int manifestId, int joinId)
    {
      var joinEntry = _db.MissionManifest.FirstOrDefault(entry => entry.MissionManifestId == joinId);
      _db.MissionManifest.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = manifestId});
    }
    public ActionResult AddMission(int id)
    {
      var thisManifest = _db.Manifests.FirstOrDefault(manifests => manifests.ManifestId == id);
      ViewBag.MissionId = new SelectList(_db.Missions, "MissionId", "MissionName");
      return View(thisManifest);
    }
    [HttpPost]
    public ActionResult AddMission(Manifest manifest, int MissionId)
    {
      if (MissionId != 0)
      {
      _db.MissionManifest.Add(new MissionManifest() { MissionId = MissionId, ManifestId = manifest.ManifestId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = manifest.ManifestId});
    }
  }
}