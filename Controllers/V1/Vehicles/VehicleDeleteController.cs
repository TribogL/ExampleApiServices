using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleApiServices.Data;
using ExampleApiServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApiServices.Controllers.V1.Vehicles;
[ApiController]
[Route("api/v1/[controller]")]
public class VehicleDeleteController : ControllerBase
{

    private readonly ApplicationDbContext _context;

    public VehicleDeleteController(ApplicationDbContext context)
    {
        _context = context;
    }  
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<Vehicle>> Delete(int id)
    {
        var Vehicle = await _context.Vehicles.FindAsync(id);
        if (Vehicle == null)
        {
            return NotFound();
        }
        _context.Vehicles.Remove(Vehicle);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    
}
