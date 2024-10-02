using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleApiServices.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleApiServices.Data;

public class ApplicationDbContext : DbContext

{
    public DbSet<Vehicle> Vehicles { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
}