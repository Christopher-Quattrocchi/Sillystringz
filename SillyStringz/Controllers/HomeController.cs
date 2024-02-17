using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Stringz.Models;

namespace SillyStringz.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
