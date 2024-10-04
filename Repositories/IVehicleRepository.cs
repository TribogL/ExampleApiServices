using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleApiServices.Models;

namespace ExampleApiServices.Repositories;
public interface IVehicleRepository
{

    Task<IEnumerable<Vehicle>> GetAll();
    Task<Vehicle?> GetById(int id);
    Task<IEnumerable<Vehicle>> GetByKeyword(string keyword);
    Task Add(Vehicle Vehicle);
    Task Update(Vehicle Vehicle);
    Task<bool> CheckExistence(int id);
    Task Delete(int id);


}
