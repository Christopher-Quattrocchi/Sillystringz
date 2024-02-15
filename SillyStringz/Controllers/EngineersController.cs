using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stringz.Models;
using System.Collections.Generic;
using System.Linq;

namespace Stringz.Controllers
{
  public class EngineersController : Controller
  {
    private readonly StringzContext _db;

    public EngineersController(StringzContext db)
    {
      _db = db;
    }

   
    public IActionResult Index()
    {
   
      return View(_db.Engineers.ToList());
    }

   
    public IActionResult Detail(int? id)
    {
      // if (id == null)
      // {
      //     return NotFound();
      // }

      Engineer engineer = _db.Engineers
          .Include(e => e.JoinEntities)
          .ThenInclude(je => je.Machine)
          .FirstOrDefault(m => m.EngineerId == id);

      // if (engineer == null)
      // {
      //     return NotFound();
      // }

      return View(engineer);
    }


    public IActionResult Create()
    {
      return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Engineer engineer)
    {

        _db.Engineers.Add(engineer);
        _db.SaveChanges();
        return RedirectToAction("Index");
      
    }


   public IActionResult Edit(int id)
    {
        // if (id == null)
        // {
        //     return NotFound();
        // }

        Engineer engineer = _db.Engineers.Include(e => e.JoinEntities).FirstOrDefault(e => e.EngineerId == id);
        // if (engineer == null)
        // {
        //     return NotFound();
        // }


        return View(engineer);
    }

    
    [HttpPost]

    public IActionResult Edit(Engineer engineer)
    {
      // if (id != engineer.EngineerId)
      // {
      //   return NotFound();
      // }
      _db.Engineers.Update(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    // public IActionResult Delete(int id)
    // {
    //   Engineer engineer = _db.Engineers.Find(engineer.EngineerId == id);
    //   return View(engineer);
    // }

    [HttpPost]
    public IActionResult Delete(int id)
    {
      Engineer engineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      _db.Engineers.Remove(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public IActionResult AddMachine(int id)
    {

    }
  }
}