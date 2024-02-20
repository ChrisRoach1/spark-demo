using System.ComponentModel.DataAnnotations;

namespace spark_demo.Application.DTOs;

public class TableFieldDto
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = default!;
    
    [Required(ErrorMessage = "Value is required")]
    public string Value { get; set; } = default!;
}