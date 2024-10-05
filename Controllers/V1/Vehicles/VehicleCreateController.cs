
using ExampleApiServices.DTOs;
using ExampleApiServices.Models;
using ExampleApiServices.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApiServices.Controllers.V1.Vehicles;
[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("vehicles")]
public class VehiclesCreateController(IVehicleRepository vehicleRepository) : VehiclesController(vehicleRepository)
{

    [HttpPost]
    public async Task<ActionResult<Vehicle>> Create(VehicleDTO inputvehicle)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newVehicle = new Vehicle(inputvehicle.Make, inputvehicle.Model, inputvehicle.Year, inputvehicle.Price, inputvehicle.Color);


      await _vehicleRepository.Add(newVehicle);

      return Ok(newVehicle);
    }


}
