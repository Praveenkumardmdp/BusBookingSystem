using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BusBookingApp.Models;

namespace BusBookingApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult ErrorView()
    {
        return View();
    }
    public IActionResult ErrorPage(string exception)
    {
        ViewBag.Error = exception;
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
