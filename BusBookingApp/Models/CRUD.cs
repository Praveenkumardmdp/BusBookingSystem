using BusBookingApp.Connections;
using BusBookingApp.bus;
using BusBookingApp.bus.Dto;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;

public class Crud
{
    private readonly Context? context;
    public Crud(Context dbContext)
    {
        this.context = dbContext;
    }
    // Context context=new Context();
    public string? username; 

    public string Checkbus(BusDetail busDetail)
    {
        var NewBus = context.busDetails.Where(b => b.registrationNo == busDetail.registrationNo).SingleOrDefault();
        if(NewBus != null)
        {
            return "No";
        }
        else
        {
            return "Yes";
        }
    } 
    public string getRegister(Login register)
    {
        var NewUser = context.logins.Where(u => u.email == register.email && u.phonenumber==register.phonenumber).SingleOrDefault();
        username=register.userName;

        string passwordHash = BCrypt.Net.BCrypt.HashPassword(register.password);
        register.password = passwordHash;

        if(NewUser == null)
        {
            context.logins.Add(register);
            context.SaveChanges();
            Console.WriteLine("Done");
            return "Done";
        }
        else
        {
            Console.WriteLine("Error");
            return "Error";
        }
    }
    
    public string getUser(Login login)
    {
        username=login.userName;
        var users = TotalUser();
        var user = context.logins.Where(p => p.userName== login.userName).FirstOrDefault();
        foreach (var Customer in users)
        {
            if(Customer.userName != login.userName)
            {
                return "notok";
            }
            if(!BCrypt.Net.BCrypt.Verify(login.password,user.password))
            {
                return "notok"; 
            }
        }
        return "ok";
    }
    public string getlogin(LoginDto login)
    {
        
        username=login.userName;
        var users = TotalUser();
        var user = context.logins.Where(p => p.userName== login.userName).FirstOrDefault();
        foreach (var Customer in users)
        {
            if(Customer.userName == login.userName)
            {
                if(BCrypt.Net.BCrypt.Verify(login.password,user.password))
                {
                    return "ok"; 
                }
            }
            
        }
        return "notok";
    }
    public List<Login> Logindetails(string username)
    {
        var user = context.logins.Where(p => p.userName == username).ToList();
        return user;
    }
    public string userid()
    {
        return username;
    }
    public void forgetpassword(Login login)
    {
        using(context)
        {
            var user = context.logins.FirstOrDefault(p => p.email == login.email);
            if(user != null)
            {
                user.password = login.password; 
                context.SaveChanges();
            }
            else 
            {
                Console.WriteLine("NULL");
            }
        };
    }

    public List<BusDetail> getList(string sourse, string destination,DateTime? date)
    {
        List<BusDetail> buslist=new List<BusDetail>();
        buslist = context.busDetails.Where(p => p.source == sourse && p.destination == destination && p.pickupDate == date).ToList();
        // Console.WriteLine("returned getbus"); 
        return buslist;
    }
    public BusDetail getBusdetail(string BusNo)
    {
        BusDetail busdetails = new BusDetail();
        busdetails = context.busDetails.Where(p=>p.registrationNo == BusNo).SingleOrDefault();
        return busdetails;
    }

    public List<BusDetail> totalBusdetail()
    {
        var busdetail = context.busDetails.Where(x => true).ToList();
        if(busdetail == null)
        {
            return null;
        }
        else
        {
            return busdetail;
        }
    }
    public void deleteBus(string registrationno)
    {
        var delete = context.busDetails.SingleOrDefault(d => d.registrationNo == registrationno);
        var remove = context.busNames.SingleOrDefault(d => d.busNumber == registrationno);
        if(delete != null)
        {
            context.busDetails.Remove(delete);
            context.busNames.Remove(remove);
            context.SaveChanges();
        }
    }
    public BusName getbus(string bus)
    {
        BusName bus1=new BusName();
        // Console.WriteLine(bus);
        bus1 = context.busNames.Where(p=>p.busNumber == bus).SingleOrDefault();            
        return bus1;
    }
    public void updateBus(BusDetail newbusdetails)
    {
        BusDetail busdetail = context.busDetails.FirstOrDefault(p=>p.registrationNo == newbusdetails.registrationNo);
        BusName busName = context.busNames.FirstOrDefault(p=>p.busNumber == newbusdetails.registrationNo);
        if (busdetail != null && busName!=null)
        {
            busdetail.Name = newbusdetails.Name;
            busdetail.source = newbusdetails.source;
            busdetail.destination = newbusdetails.destination;
            // busdetail.busfare = newbusdetails.busfare;
            // busdetail.bustype = newbusdetails.bustype;
            // busdetail.dropDate = newbusdetails.dropDate;
            busdetail.droptime = newbusdetails.droptime;
            busdetail.pickupDate = newbusdetails.pickupDate;
            busdetail.pickuptime = newbusdetails.pickuptime;

            busName.busName = newbusdetails.Name;
            busName.pickupplace = newbusdetails.source;
            busName.dropplace = newbusdetails.destination;
            busName.pickuptime = newbusdetails.pickuptime;
            busName.droptime = newbusdetails.droptime;
            busName.pickupDate = newbusdetails.pickupDate;
            // busName.dropDate = newbusdetails.dropDate;
            context.SaveChanges();
        }
        // Console.WriteLine(busName.busname);
    }
    public BusDetail getfullBusDetail(string busno)
    {
        BusDetail busdetail = new BusDetail();
        busdetail = context.busDetails.Where(p=>p.registrationNo == busno).FirstOrDefault();
        return busdetail;
    }
    public List<Login> GetMyAccount(string username)
    {
        List<Login> Login = new List<Login>();
        Login = context.logins.Where(p=>p.userName == username).ToList();
        return Login;
    }
    public void updateseats(List<string> buttonvalues, string busno, string type,string username)
    {
        using (var transaction = context.Database.BeginTransaction())
        {
            try
            {
                // Your existing logic here...
                Console.WriteLine(buttonvalues);
                Console.WriteLine(busno);
                Console.WriteLine(type);
                var BusDetail = context.busDetails.Where(p=>p.registrationNo==busno).ToList();
                
                string seatno="";
                string seatno1="";
                var bus = context.busNames.Where(p => p.busNumber == busno).SingleOrDefault();
                var user = context.user.Where(p=>p.userName == username & p.registrationno == busno).ToList();
                foreach(var item in user)
                {
                    context.user.Remove(item);
                }
                
                if(bus!=null)
                {
                    if(type=="update")
                    {
                        foreach (var item in buttonvalues)
                        {
                            if (item != "0")
                            {
                                seatno=seatno+item+",";
                                string seat = "_" + item;  
                                var seatProperty = typeof(BusName).GetProperty(seat);
                                if (seatProperty != null)
                                {
                                    seatProperty.SetValue(bus, username);
                                    context.SaveChanges();
                                }
                            }
                        }
                        

                    } 
                    if(type=="cancel")
                    {
                        foreach (var item in buttonvalues)
                        {
                            string seat = "_" + item; 
                            var seatProperty = typeof(BusName).GetProperty(seat);
                            Console.WriteLine(item);
                        if (item != "0")
                        {
                                seatno=seatno+item+","; 
                                if (seatProperty != null)
                                {                   
                                seatProperty.SetValue(bus, null);
                                }        

                            }   
                            context.SaveChanges();
                        }   
                        
                    }
                    
                    if( bus._1==username)
                    {
                        seatno1=seatno1+"1"+",";
                    }
                    if( bus._2==username)
                    {
                        seatno1=seatno1+"2"+",";                
                    }
                    if( bus._3==username)
                    {
                        seatno1=seatno1+"3"+",";                
                    }
                    if( bus._4==username)
                    {
                        seatno1=seatno1+"4"+",";;                
                    }
                    if( bus._5==username)
                    {
                        seatno1=seatno1+"5"+",";                
                    }
                    if( bus._6==username)
                    {
                        seatno1=seatno1+"6"+",";                
                    }
                    if( bus._7==username)
                    {
                        seatno1=seatno1+"7"+",";                
                    }
                    if( bus._8==username)
                    {
                        seatno1=seatno1+"8"+",";                
                    }
                    if( bus._9==username)
                    {
                        seatno1=seatno1+"9"+",";                
                    }
                    if(  bus._10==username)
                    {
                        seatno1=seatno1+"10"+",";                
                    }
                    if( bus._11==username)
                    {
                        seatno1=seatno1+"11"+",";
                    }
                    if(  bus._12==username)
                    {
                        seatno1=seatno1+"12"+",";                
                    }
                    if(  bus._13==username)
                    {
                        seatno1=seatno1+"13"+",";                
                    }
                    if(  bus._14==username)
                    {
                        seatno1=seatno1+"14"+",";                
                    }
                    if( bus._15==username)
                    {
                        seatno1=seatno1+"15"+",";                
                    }
                    if(bus._16==username)
                    {
                        seatno1=seatno1+"16"+",";               
                    }
                    if(bus._17==username)
                    {
                        seatno1=seatno1+"17"+",";                
                    }
                    if( bus._18==username)
                    {
                        seatno1=seatno1+"18"+",";                
                    }
                    if(bus._19==username)
                    {
                        seatno1=seatno1+"19"+",";                
                    }
                    if( bus._20==username)
                    {
                        seatno1=seatno1+"20"+",";                
                    }     
                    if(  bus._21==username)
                    {
                        seatno1=seatno1+"21"+",";
                    }
                    if( bus._22==username)
                    {
                        seatno1=seatno1+"22"+",";                
                    }
                    if( bus._23==username)
                    {
                        seatno1=seatno1+"23"+",";                
                    }
                    if(bus._24==username)
                    {
                        seatno1=seatno1+"24"+",";                
                    }
                    if( bus._25==username)
                    {
                        seatno1=seatno1+"25"+",";                
                    }
                    if( bus._26==username)
                    {
                        seatno1=seatno1+"26"+",";                
                    }
                    if(bus._27==username)
                    {
                        seatno1=seatno1+"27"+",";                
                    }
                    if(bus._28==username)
                    {
                        seatno1=seatno1+"28"+",";                
                    }
                    if( bus._29==username)
                    {
                        seatno1=seatno1+"29"+",";                
                    }
                    if(bus._30==username)
                    {
                        seatno1=seatno1+"30"+",";                
                    }  
                    if( bus._31==username)
                    {
                        seatno1=seatno1+"31"+",";
                    }
                    if( bus._32==username)
                    {
                        seatno1=seatno1+"32"+",";                
                    }
                    if(bus._33==username)
                    {
                        seatno1=seatno1+"33"+",";                
                    }
                    if(bus._34==username)
                    {
                        seatno1=seatno1+"34"+",";                
                    }
                    if(bus._35==username)
                    {
                        seatno1=seatno1+"35"+",";                
                    }
                    if(bus._36==username)
                    {
                        seatno1=seatno1+"36"+",";                
                    }
                    if(bus._37==username)
                    {
                        seatno1=seatno1+"37"+",";                
                    }
                    if( bus._38==username)
                    {
                        seatno1=seatno1+"38"+",";                
                    }
                    if( bus._39==username)
                    {
                        seatno1=seatno1+"39"+",";                
                    }
                    if( bus._40==username)
                    {
                        seatno1=seatno1+"40"+",";                
                    } 
                    if( bus._41==username)
                    {
                        seatno1=seatno1+"41"+","; 
                    }
                    if( bus._42==username)
                    {
                        seatno1=seatno1+"42"+",";                 
                    }
                    if( bus._43==username)
                    {
                        seatno1=seatno1+"43"+",";                 
                    }
                    if(bus._44==username)
                    {
                        seatno1=seatno1+"44"+",";                 
                    }
                        // string Busname = 
                    foreach (var item in BusDetail)
                    {
                        User user1=new User{userName=username,busname=bus.busName,registrationno=busno,seatno=seatno1, /*busfare=item.busfare,*/ source=bus.pickupplace ,destination=bus.dropplace, pickupDate=bus.pickupDate, pickuptime=bus.pickuptime, /*dropDate=bus.dropDate,*/ droptime=bus.droptime};
                        context.user.Add(user1);
                        context.SaveChanges();
                    }               
                }
                // Save changes and commit the transaction
                context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                // Handle exceptions and log them
                Console.WriteLine(ex.Message);
                transaction.Rollback();
                throw; // Rethrow the exception to indicate a failure
            }
        }
        
    }
    public List<User> getbookedbuses(string username)
    { 
        var  bookedbus=context.user.Where(p=>p.userName==username).ToList();
        foreach (var item in bookedbus)
        {
            if(item.seatno == "" )
            {
                context.user.Remove(item);
                return null;
            }
            else
            {
                break;
            }
        }
        return bookedbus;
    }

    public void modifypassword(Login login,string newpassword)
    {
        var user = context.logins.Where(p => p.userName == login.userName && p.password == login.password).FirstOrDefault();
        if(user != null)
        {
            user.password = newpassword; 
            context.SaveChanges();
        }
    }
    public void modifyPhonenumber(Login login,string phonenumber)
    {
        var user = context.logins.Where(un => un.userName==login.userName && un.password ==login.password).FirstOrDefault();
        user.phonenumber = phonenumber;
        context.SaveChanges();
    }
    public void modifyEmail(Login login,string email)
    {
        var phone = context.logins.Where(un => un.userName==login.userName && un.password ==login.password).FirstOrDefault();
        phone.email = email;
        context.SaveChanges();
    }

    public void addBus(BusDetail addbus)
    {
        context.busDetails.Add(addbus);
        BusName busName = new BusName();
        busName.busName=addbus.Name;
        busName.busNumber = addbus.registrationNo;
        busName.pickupplace = addbus.source;
        busName.dropplace = addbus.destination;
        busName.pickuptime = addbus.pickuptime;
        busName.droptime = addbus.droptime;
        busName.pickupDate = addbus.pickupDate;
        // busName.dropDate = addbus.dropDate;

        context.busNames.Add(busName);
        context.SaveChanges();
        // Console.WriteLine(addbus.pickupDate.Date);
    }

    public List<Login> TotalUser()
    {
        List<Login> TotalUsers = context.logins.Where(x=> true).ToList();
        return TotalUsers;
    }
}
// new List<login>();