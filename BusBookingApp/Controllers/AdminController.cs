using Microsoft.AspNetCore.Mvc;
using BusBookingApp.bus;
using Alias = System.Collections.Generic.List<BusBookingApp.bus.BusDetail>;
using BusBookingApp.Connections;
using BusBookingApp.Validation;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;

namespace BusBookingWeb.Controllers;

public class AdminController : Controller
{   
    private readonly Crud? crud;
    private readonly HttpClient _httpClient;

    public AdminController(Context dbContext)
    {
        crud = new Crud(dbContext);
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new System.Uri("https://localhost:7088/"); // Replace with your Web API URL
    }

    public async Task<IActionResult> totalBus()
    {
        var response = await _httpClient.GetAsync("api/BusDetail");
        if(response.IsSuccessStatusCode)
        {
            // var login = await response.Content.ReadAsAsync<
            var busdetails = await response.Content.ReadAsAsync<IEnumerable<BusDetail>>();
            return View ("TotalBus",busdetails);
        }
        return View("TotalBus");

        //Before using the Alias
        // List<BusDetail> busDetails = new List<BusDetail>();

        //After using the Alias

        // Alias busdetails = new Alias();
        // busdetails = crud.totalBusdetail();
        // if(busdetails == null)
        // {
        //     return new EmptyResult();
        // }
        // return View ("TotalBus",busdetails);
    }

    [HttpGet]
    public async Task<IActionResult> UserProfiles()
    {
        var response = await _httpClient.GetAsync("api/Login");
        if(response.IsSuccessStatusCode)
        {
            var login = await response.Content.ReadAsAsync<IEnumerable<Login>>();
            return View("UserDetails",login);
        }
        return View("UserDetails");
    }

    public IActionResult AddBus()
    {
        return View ();
    }

    public IActionResult RemoveBus(string registrationno)
    {
        crud.deleteBus(registrationno);
        return RedirectToAction("totalBus","Admin");
    }
    
    [HttpGet]
    public IActionResult Edit(string registrationno)
    {
        BusDetail busdetails = new BusDetail();
        busdetails=crud.getfullBusDetail(registrationno);
        return View(busdetails);
    }

    [HttpPost]
    public IActionResult Edit(BusDetail busdetails)
    {
        crud.updateBus(busdetails);
        var RedirectUrl = Url.Action("totalBus","Admin");
        if(RedirectUrl != null)
        {
            return Redirect(RedirectUrl);
        }
        return View();
    }

    public IActionResult Settings()
    {    
        return View ();    
    }

    public async Task<IActionResult> InsertBus(BusDetail busdetail)
    {
        if(!ModelState.IsValid)
        {
            return View("AddBus",busdetail);
        }
        string NewBus=crud.Checkbus(busdetail);
        if(NewBus == "Yes")
        {
            crud.addBus(busdetail);
            // var response = await _httpClient.PostAsync("api/BusDetail",busdetail);
            Console.WriteLine("Done");
        }
        return RedirectToAction("AddBus","Admin");
    }

    public IActionResult Bookings(string Mail)
    {
        return View();
    }
}
