using Spark.Library.Database;

namespace spark_demo.Application.Models;

public class Table : BaseModel
{

    public string Name { get; set; } = default!;

    public int UserID { get; set; }
    
    public virtual User User { get; set; } 
    
    public virtual ICollection<TableField> TableFields { get; set; }
}