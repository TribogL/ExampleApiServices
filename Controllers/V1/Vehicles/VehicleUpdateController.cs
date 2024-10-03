using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleApiServices.Data;
using ExampleApiServices.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApiServices.Controllers.V1.Vehicles;
[ApiController]
[Route("api/v1/[controller]")]
public class VehicleUpdateController : ControllerBase
{

    private readonly ApplicationDbContext _context;

    public VehicleUpdateController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> Update(int id, VehicleDTO updateVehicle)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var Vehicle = await _context.Vehicles.FindAsync(id);
        if (Vehicle == null)
        {
            return NotFound();
        }
        Vehicle.Make = updateVehicle.Make;
        Vehicle.Model = updateVehicle.Model;
        Vehicle.Year = updateVehicle.Year;
        Vehicle.Price = updateVehicle.Price;
        Vehicle.Color = updateVehicle.Color;

        _context.Vehicles.Update(Vehicle);
        await _context.SaveChangesAsync();

        return NoContent();

    }

}
