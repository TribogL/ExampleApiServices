using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleApiServices.Data;
using ExampleApiServices.Models;
using ExampleApiServices.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExampleApiServices.Services;
public class VehicleServices : IVehicleRepository
{
    private readonly ApplicationDbContext _context;

    public VehicleServices(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Add(Vehicle Vehicle)
    {
        if (Vehicle == null)
        {
            throw new ArgumentNullException(nameof(Vehicle), "El vehiculo no puede ser nulo.");
        }

        try
        {
            await _context.Vehicles.AddAsync(Vehicle);
            await _context.SaveChangesAsync();
        }

        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error al agregar el vehiculo a la base de datos.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Ocurrió un erro inesperado al agregar el vehiculo:", ex);
        }
    }

    public async Task<bool> CheckExistence(int id)
    {

        try
        {
            return await _context.Vehicles.AnyAsync(v => v.Id == id);
        }

        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error al agregar el vehiculo a la base de datos.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Ocurrió un erro inesperado al agregar el vehiculo:", ex);
        }
    }

    public async Task Delete(int id)
    {
        var Vehicle = await _context.Vehicles.FindAsync(id);
        if (Vehicle! == null)
        {
            _context.Vehicles.Remove(Vehicle);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Vehicle>> GetAll()
    {
        return await _context.Vehicles.ToListAsync();
    }

    public async Task<Vehicle?> GetById(int id)
    {
        return await _context.Vehicles.FindAsync(id);
    }

    public async Task Update(Vehicle Vehicle)
    {
        if (Vehicle == null)
        {
            throw new ArgumentNullException(nameof(Vehicle), "El vehiculo no puede ser nulo.");
        }

        try
        {
            await _context.Vehicles.AddAsync(Vehicle);
            await _context.SaveChangesAsync();
        }

        catch (DbUpdateException dbEx)
        {
            throw new Exception("Error al agregar el vehiculo a la base de datos.", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Ocurrió un erro inesperado al agregar el vehiculo:", ex);
        }
    }
}
