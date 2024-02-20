using Spark.Library.Database;

namespace spark_demo.Application.Models;

public class TableField : BaseModel
{
    public string Name { get; set; } = default!;

    public string Value { get; set; } = default!;

    public int TableID { get; set; }
    
    public virtual Table Table { get; set; } 
}