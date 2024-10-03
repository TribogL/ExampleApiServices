using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using ExampleApiServices.Data;
using ExampleApiServices.DTOs;
using ExampleApiServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExampleApiServices.Controllers.V1.Vehicles;
[ApiController]
[Route("api/v1/[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public VehiclesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vehicle>>> GetAll()
    {
        return await _context.Vehicles.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Vehicle>> GetById(int id)
    {
        var Vehicle = await _context.Vehicles.FindAsync(id);
        if(Vehicle == null)
        {
            return NotFound();
        }
        return Vehicle;
    }

    [HttpPost]
    public async Task<ActionResult<Vehicle>> Create(VehicleDTO inputvehicle)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var  newVehicle = new Vehicle(inputvehicle.Make, inputvehicle.Model, inputvehicle.Year, inputvehicle.Price, inputvehicle.Color);

        _context.Vehicles.Add(newVehicle);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new {id = newVehicle.Id}, inputvehicle);
    }

}
