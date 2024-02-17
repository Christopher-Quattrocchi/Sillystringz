using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stringz.Models;
using System.Linq;

namespace Stringz.Controllers
{
  public class MachinesController : Controller
  {
    private readonly StringzContext _db;

    public MachinesController(StringzContext db)
    {
      _db = db;
    }

    public IActionResult Index()
    {
      return View(_db.Machines.ToList());
    }

    public IActionResult Details(int? id)
    {
      Machine machine = _db.Machines
          .Include(m => m.Engineers)
          .ThenInclude(je => je.Engineer)
          .FirstOrDefault(e => e.MachineId == id);

      return View(machine);
    }

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Machine machine)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
      Machine machine = _db.Machines.Find(id);
      return View(machine);
    }

    [HttpPost]
    public IActionResult Edit(Machine machine)
    {
      _db.Update(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
      Machine machine = _db.Machines.Find(id);

      _db.Machines.Remove(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}