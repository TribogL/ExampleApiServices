
using ExampleApiServices.Models;
using ExampleApiServices.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApiServices.Controllers.V1.Vehicles;
[ApiController]
[Route("api/v1/[controller]")]
public class VehiclesGetController : ControllerBase
{
    private readonly IVehicleRepository _vehicleRepository;

    public VehiclesGetController(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vehicle>>> GetAll()
    {
        var Vehicles = await _vehicleRepository.GetAll();
        return Ok(Vehicles);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Vehicle>> GetById(int id)
    {
        var Vehicle = await _vehicleRepository.GetById(id);
        if (Vehicle == null)
        {
            return NotFound();
        }

        await _vehicleRepository.GetById(id);

        return NoContent();
    }

    [HttpGet("search/{keyword}")]
    public async Task<ActionResult<IEnumerable<Vehicle>>> SearchByKeyword(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
        {
            return BadRequest("La palabra clave no puede estar vacía.");
        }

        var vehicles = await _vehicleRepository.GetByKeyword(keyword);

        if (!vehicles.Any())
        {
            return NotFound("No se encontraron vehículos que coincidan con la palabra clave proporcionada.");
        }

        return Ok(vehicles);
    }

}