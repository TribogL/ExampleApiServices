using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleApiServices.Data;
using ExampleApiServices.DTOs;
using ExampleApiServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApiServices.Controllers.V1.Vehicles;
[ApiController]
[Route("api/v1/[controller]")]
public class VehicleCreateController : ControllerBase
{

  private readonly ApplicationDbContext _context;

    public VehicleCreateController(ApplicationDbContext context)
    {
        _context = context;
    }  

    [HttpPost]
    public async Task<ActionResult<Vehicle>> Create(VehicleDTO inputvehicle)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newVehicle = new Vehicle(inputvehicle.Make, inputvehicle.Model, inputvehicle.Year, inputvehicle.Price, inputvehicle.Color);

        _context.Vehicles.Add(newVehicle);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Create), new { id = newVehicle.Id }, inputvehicle);
    }
    

}
