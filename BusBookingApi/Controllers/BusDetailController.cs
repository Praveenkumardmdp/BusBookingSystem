using BusBookingApi.Data;
using BusBookingApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusBookingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BusDetailController : ControllerBase
{
    private readonly Context _Context;
    public BusDetailController(Context Context)
    {
        _Context = Context;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BusDetail>>> TotalBus()
    {
        var TotalUsers = await _Context.busDetails.ToListAsync();
        return Ok(TotalUsers);
    }

    [HttpPost]
    public async Task<ActionResult<BusDetail>> AddBusDetail([FromBody]BusDetail busDetail)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _Context.busDetails.Add(busDetail);
                await _Context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetBusDetailById), new { id = busDetail.serialNo }, busDetail);
                }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        return BadRequest(ModelState);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BusDetail>> GetBusDetailById(int id)
    {
        var busDetail = await _Context.busDetails.FindAsync(id);
        if (busDetail == null)
        {
            return NotFound();
        }
        return Ok(busDetail);
    }

    [HttpGet("GetByRegistrationNo/{registrationNo}")]
    public async Task<ActionResult<BusDetail>> GetBusDetailByRegistrationNo(string registrationNo)
    {
        var busDetail = await _Context.busDetails.FirstOrDefaultAsync(b => b.registrationNo == registrationNo);

        if (busDetail == null)
        {
            return NotFound();
        }

        return Ok(busDetail);
    }
}