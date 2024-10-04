using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleApiServices.Data;
using ExampleApiServices.Models;
using ExampleApiServices.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApiServices.Controllers.V1.Vehicles;
[ApiController]
[Route("api/v1/[controller]")]
public class VehicleDeleteController : ControllerBase
{

    private readonly IVehicleRepository _vehicleRepository;

    public VehicleDeleteController(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Vehicle>> Delete(int id)
    {
        var Vehicle = await _vehicleRepository.CheckExistence(id);
        if (Vehicle == false)
        {
            return NotFound();
        }

        await _vehicleRepository.Delete(id);

        return NoContent();
    }

}
