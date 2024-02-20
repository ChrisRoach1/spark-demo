using System.ComponentModel.DataAnnotations;

namespace spark_demo.Application.DTOs;

public class TableDto
{

    public int? ID { get; set; } = default!;
    
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = default!;

    [ValidateComplexType]
    public List<TableFieldDto> tableFields { get; set; } = default!;
}