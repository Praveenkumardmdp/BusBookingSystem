using Microsoft.AspNetCore.Mvc;
using BusBookingApp.bus;
using BusBookingApp.Connections;

namespace BusBookingApp.Controllers;

public class EditController : Controller
{
    private readonly Crud? crud;
    public EditController(Context dbContext)
    {
        crud = new Crud(dbContext);
    }   
    // string? username; 

    // string? getusername;
    [HttpGet]
    public IActionResult ChangePhoneNumber()
    {
        return View();
    }
    [HttpPost]
    public IActionResult ChangePhoneNumber(string username,string password,string phonenumber)
    {
        ViewBag.getusername = HttpContext.Session.GetString("username");
        Login login = new()
        {
            userName = username,
            password = password
        };
        ViewBag.username = phonenumber;

        string? confirm= crud.getUser(login);
        if(confirm == "ok")
        {
            crud.modifyPhonenumber(login,phonenumber);
            return RedirectToAction("HomePage","Client");
        }
        else
        {
            return View("ChangePhoneNumber");
        }
        // return View();
    }
    [HttpGet]
    public IActionResult ChangePassword()
    {
        return View();
    }
    [HttpPost]
    public IActionResult ChangePassword(string username,string password,string newpassword)
    {
        ViewBag.getusername = HttpContext.Session.GetString("username");
        Login login = new()
        {
            userName = username,
            password = password
        };
        string? newPassword = newpassword;
        string? confirm= crud.getUser(login);
        if(confirm == "ok")
        {
            crud.modifypassword(login , newPassword);
            return RedirectToAction("HomePage","Client");
        }
        else
        {
            return View("ChangePassword");
        }
        // return View();
    }
    [HttpGet]
    public IActionResult ChangeEmail()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ChangeEmail(string username,string password,string email)
    {
        ViewBag.getusername = HttpContext.Session.GetString("username");
        Login login = new()
        {
            userName = username,
            password = password
        };
        ViewBag.email = email;

        string? confirm= crud.getUser(login);
        if(confirm == "ok")
        {
            crud.modifyEmail(login,email);
            return RedirectToAction("HomePage","Client");
        }
        else
        {
            return View("ChangeEmail");
        }
    }
}