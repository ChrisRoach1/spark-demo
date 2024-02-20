using Microsoft.EntityFrameworkCore;
using spark_demo.Application.Database;
using spark_demo.Application.DTOs;
using spark_demo.Application.Models;
using spark_demo.Application.Services.Auth;
using Spark.Library.Extensions;

namespace spark_demo.Application.Services;

public class TableService
{


    private readonly DatabaseContext _db;
    private readonly HttpContext _httpContext;
    private readonly AuthService _auth;

    public TableService(DatabaseContext db, HttpContextAccessor HttpContext, AuthService authService)
    {
        _db = db;
        _httpContext = HttpContext.HttpContext;
        _auth = authService;
    }
    
    public async Task<List<Table>> GetTablesByUser(int userId)
    {
        return await _db.Tables.Where(x => x.UserID == userId).ToListAsync();
    }
    
    public async Task<Table> GetTablesById(int tableId)
    {
        var userID = _auth.GetAuthenticatedUserId(_httpContext.User);
        if (userID.HasValue)
        {
            var table = _db.Tables.Include(x => x.TableFields).FirstOrDefault(x => x.Id == tableId && x.UserID == userID.Value);
            return table;
        }

        return null;
    }
    
    public async Task<Table> GetTablesByName(string tableName)
    {
        return _db.Tables.Include(x => x.TableFields).FirstOrDefault(x => x.Name == tableName);
    }
    
    public async Task DeleteTableById(int tableId)
    {
        var userID = _auth.GetAuthenticatedUserId(_httpContext.User);
        var table = await _db.Tables.Where(x => x.Id == tableId && x.UserID == userID).FirstOrDefaultAsync();

        if (table != null)
        {
            _db.Tables.Remove(table);
            await _db.SaveChangesAsync();
        }
    }
    
    public void CreateTableForUser(TableDto table)
    {
        var userID = _auth.GetAuthenticatedUserId(_httpContext.User);
        
        if (userID.HasValue)
        {
            var tableToAdd = new Table
            {
                UserID = userID.Value,
                Name = table.Name
            };

            tableToAdd.TableFields = new List<TableField>();
            
            foreach (var field in table.tableFields)
            {
                tableToAdd.TableFields.Add(new TableField
                {
                    Name = field.Name,
                    Value = field.Value
                });
            }
            
            _db.Tables.Save(tableToAdd);   
        }
    }
    
    public void UpdateTableForUser(TableDto table)
    {
        var userID = _auth.GetAuthenticatedUserId(_httpContext.User);
        var updateEntity =  _db.Tables.Include(x => x.TableFields).FirstOrDefault(x => x.Id == table.ID && x.UserID == userID.Value);

        if (updateEntity != null)
        {
            updateEntity.Name = table.Name;

            updateEntity.TableFields = new List<TableField>();
            
            foreach (var field in table.tableFields)
            {
                updateEntity.TableFields.Add(new TableField
                {
                    Name = field.Name,
                    Value = field.Value
                });
            }
            
            _db.Tables.Save(updateEntity);   
        }
    }
    
}