using Microsoft.AspNetCore.Mvc;
using BusBookingApp.Connections;
using BusBookingApp.bus;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Net;
using System.Net.Mail;
using BusBookingApp.Validation;
using Alias = System.Collections.Generic.List<BusBookingApp.bus.BusDetail>;
using BusBookingApp.bus.Dto;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

public class ClientController : Controller
{
    private readonly Context context;
    private readonly IConfiguration _configuration;
    private readonly Crud crud;
    public ClientController(Context dbContext,IConfiguration configuration)
    {
        this.context = dbContext;
        _configuration = configuration;
        crud = new Crud(dbContext);
    }   
    string username = null!;

    private string CreateToken(LoginDto user)
        {
            List<Claim> claims = new()
            {
                new(ClaimTypes.Name,user.userName),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!
            ));

            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires : DateTime.Now.AddDays(1),
                signingCredentials : creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

    [CustomAuthorizeFilter]
    public IActionResult Homepage()
    {
        ViewBag.username = HttpContext.Session.GetString("username");
        return View();
    }
    public IActionResult loginuser(LoginDto login)
    {
        if(ModelState.IsValid)
        {
            try
            {
                ViewBag.username = login.userName;
                HttpContext.Session.SetString("username",login.userName);
                username=login.userName;
                // string? confirm= crud.getlogin(login);
                if((login.userName=="Admin" || login.userName=="admin") && (login.password=="Admin@123"))
                {
                    ViewBag.username=username;
                    var jwtToken = CreateToken(login);
                    return RedirectToAction("AddBus","Admin");
                }
                else
                {
                    string? confirm= crud.getlogin(login);
                    if(confirm == "ok")
                    {
                        var jwtToken = CreateToken(login);
                        ViewBag.username=username;
                        HttpContext.Session.SetObjectAsJson("logusers", login);
                        return RedirectToAction("HomePage");
                    }
                    else
                    {   
                        Console.WriteLine("Came here");
                        ModelState.AddModelError("name","Invalid username or password");
                    }
                }
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(string.Empty,$"{exception.Message}");
            }
            
        }
        foreach (var value in ModelState.Values)
        {
            foreach (var error in value.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
        }

        return RedirectToAction("Login","Home");
    }
    public IActionResult Registeruser(Login login)
    {
        if(ModelState.IsValid)
        {
            try
            {
                username =login.userName;       
                HttpContext.Session.SetString("username",login.userName);
                ViewBag.username = HttpContext.Session.GetString("username");
                var Process =crud.getRegister(login);
                if(Process == "Done")
                {
                    if(login.userName != "Admin" || login.userName != "admin")
                        return RedirectToAction("HomePage");
                    else
                        return RedirectToAction("AddBus","Admin");

                }
                else
                {
                    return RedirectToAction("Register");
                }
            }
            catch(Exception exception)
            {
                ModelState.AddModelError(string.Empty,$"Something Went Wrong{exception.Message}");
            }
        }
        ModelState.AddModelError(string.Empty,$"Something Went Wrong Model is Invalid");
        return RedirectToAction("Register");
    }  
   
    public IActionResult Forgotview()
    {
        return View ("Forgot");
    }  
    public IActionResult login()
    {        
        return View ("login");   
    }
    public IActionResult Register()
    {
        return View ();
    }
    public IActionResult Resetview()
    {    
        return View ("Reset");        
    }  
    public IActionResult resetpassword()
    {
        Login login=new Login();
        login.email=Request.Form["email"];
        login.password=Request.Form["password"];
        
        crud.forgetpassword(login);
        ViewBag.username=HttpContext.Session.GetString("username");
        return RedirectToAction("Login","Home");
    }
    public IActionResult getHome()
    {
        // username=crud.userid();    
        ViewBag.username=HttpContext.Session.GetString("username");
        return RedirectToAction("HomePage");
    } 
    public IActionResult getsearch(string source,string destination,DateTime? date)
    {
        ViewBag.username=HttpContext.Session.GetString("username");

        //Before Using the Alias  
        // List<BusDetail> buslist = new List<BusDetail>();

        //After using the Alias 
        Alias buslist = new Alias();
        buslist =crud.getList(source,destination,date);

        return View ("BusList",buslist);
    }
    public IActionResult getBookedbus()
    {
        username=HttpContext.Session.GetString("username");
        ViewBag.Bookings=crud.getbookedbuses(username);
        ViewBag.username = username;
        if (ViewBag.Bookings == null)
        {
            return View("EmptyView");
            // return EmptyView();
            // return new EmptyResult();
        }
        return View ("Bookedbus");        
    }
    public IActionResult EmptyView()
    {
        return View();
    }
    public IActionResult PrintTicket(int ticketId)
    {
        using ( context)
        {
            var ticket = context.user.Find(ticketId);

            byte[] pdfBytes;
            using (var ms = new MemoryStream())
            {
                var document = new Document(PageSize.A4, 50, 50, 25, 25);
                var writer = PdfWriter.GetInstance(document, ms);
                document.Open();
                document.Add(new Paragraph("Ticket Information"));           
                document.Add(new Paragraph($"Passenger Name: {ticket.userName}"));
                document.Add(new Paragraph($"Bus no: {ticket.registrationno}"));
                document.Add(new Paragraph($"Pickup Place: {ticket.source}"));
                document.Add(new Paragraph($"Date: {ticket.pickupDate}"));
                document.Add(new Paragraph($"Time: {ticket.pickuptime}"));
                document.Add(new Paragraph($"Drop Place: {ticket.destination}"));
                document.Add(new Paragraph($"Drop Place: {ticket.seatno}"));
                document.Close();
                pdfBytes = ms.ToArray();
            }

            return File(pdfBytes, "application/pdf", "ticket.pdf");
        }
    }

    public IActionResult CancelTicket(string bus,string sno)
    {
        // Context context=new Context();
        ViewBag.busname=context.busNames.Where(p=>p.busNumber==bus).SingleOrDefault();
        username=HttpContext.Session.GetString("username");
        ViewBag.username=username;
        ViewBag.sno=sno;
        // Console.WriteLine(ViewBag.busname.busno);
        return View ("CancelTicket");
    }   
    
    public void sendMail()
    {
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress("praveenkumar.1903112@srec.ac.in");
        string? email=Request.Form["email"];
        mailMessage.To.Add(email);
        mailMessage.Subject = "Reset your password";
        mailMessage.Body = "Please click on the following link to reset your password: " + "https://localhost:7121/Client/Resetview";

        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential("praveenkumar.1903112@srec.ac.in", "Praveen24@");
        smtpClient.EnableSsl = true;
        smtpClient.Send(mailMessage); 
    }
    
    public IActionResult getbus(string bus)
    {
        // Console.WriteLine(bus);
        BusDetail busdetails = new BusDetail();
        try
        {
            busdetails = crud.getBusdetail(bus);
        }
        catch(Exception exception)
        {
            var exceptionMessage = exception.Message;
            return RedirectToAction("ErrorPage","Home",new{exception = exceptionMessage});
        }
        // ViewBag.busfare= busdetails.busfare;
        BusName bustable=new BusName();
        bustable=crud.getbus(bus);
        
        ViewBag.busname=bustable;
        ViewBag.username=HttpContext.Session.GetString("username");
        return View ("BusSeatSelect");
    } 
    public IActionResult selectedseats(List<string> buttonvalues,string busNumber,string type )
    {
        Console.WriteLine(buttonvalues);
        Console.WriteLine(busNumber);
        Console.WriteLine(type);
        // Console.log(buttonvalues);
        if(buttonvalues==null)
        {
        }
        else
        {    
            username=HttpContext.Session.GetString("username");      
            crud.updateseats(buttonvalues,busNumber,type,username);
        }
        ViewBag.username=HttpContext.Session.GetString("username");
        return RedirectToAction("getBookedbus");
    }
    public IActionResult Help()
    {
        ViewBag.username=HttpContext.Session.GetString("username");
        return View();
    }
    public IActionResult Logout()
    {
        return View();
    }
    
    [CustomAuthorizeFilter]
    public IActionResult GetMyAccount()
    {
        string username = HttpContext.Session.GetString("username");
        List<Login> login = new List<Login>();
        login = crud.GetMyAccount(username);
        return View("MyAccount",login);
    }



}