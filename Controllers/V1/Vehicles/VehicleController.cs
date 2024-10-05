
using ExampleApiServices.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApiServices.Controllers.V1.Vehicles
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController(IVehicleRepository vehicleRepository) : ControllerBase
    {
        protected readonly IVehicleRepository _vehicleRepository = vehicleRepository;
    }
}