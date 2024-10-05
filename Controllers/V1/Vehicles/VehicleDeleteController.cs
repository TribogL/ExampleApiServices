
using ExampleApiServices.Models;
using ExampleApiServices.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApiServices.Controllers.V1.Vehicles;
[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("vehicles")]
public class VehicleDeleteController(IVehicleRepository vehicleRepository) : VehiclesController(vehicleRepository)
{

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
