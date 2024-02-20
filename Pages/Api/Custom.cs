using System.Dynamic;
using spark_demo.Application.Services;
using Spark.Library.Routing;
using spark_demo.Application.DTOs;


namespace spark_demo.Pages.Api;

public class Custom() : IRoute
{
    
    public void Map(WebApplication app)
    {
        app.MapGet("/api/custom", async (string table, TableService tableService, BogusService bogusService) =>
        {
            var tableToQuery = await tableService.GetTablesByName(table);
            List<object> myList = new List<object>();            
            var test = tableToQuery.TableFields.Select(x => new TableFieldDto
            {
                Name = x.Name,
                Value = bogusService.returnBogusValue(x.Value)
            }).ToList();
            
            for (var i = 0; i < 250; i++)
            {
                var dataSet = new ExpandoObject() as IDictionary<string, Object>;
                foreach (var tableField in tableToQuery.TableFields)
                {
                    var value = bogusService.returnBogusValue(tableField.Value);
                    dataSet.Add(tableField.Name, value);
                }
                
                myList.Add(dataSet);
            }
            
            return Results.Ok(myList);
        });
    }
}