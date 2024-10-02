using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleApiServices.DTOs;

public class VehicleDTO
{
    [Required(ErrorMessage ="La marca es oblicgatoria")]
    [StringLength(50, ErrorMessage ="La marca no puede eceder los 50 caracteres")]
    public required string Make { get; set; }
    [Required(ErrorMessage ="El modelo es oblicgatoria")]
    [StringLength(50, ErrorMessage ="El marca no puede eceder los 50 caracteres")]
    public required string Model { get; set; }

    [Range(1960, 2025, ErrorMessage ="El año debe estar entre 1960 y el año actual")]
    public int Year { get; set; }

    [Range(0, double.MaxValue, ErrorMessage ="El debe ser un valor positivo")]
    public required string Price { get; set; }

    [Required(ErrorMessage ="El color es oblicgatoria")]
    [StringLength(50, ErrorMessage ="El color no puede eceder los 50 caracteres")]
    public required string Color { get; set; }

}