using spark_demo.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace spark_demo.Application.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    { }

    public virtual DbSet<User> Users { set; get; }
    public virtual DbSet<Role> Roles { set; get; }
    public virtual DbSet<UserRole> UserRoles { get; set; }
    
    public virtual DbSet<Table> Tables { set; get; }
    
    public virtual DbSet<TableField> TableFields { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        // it should be placed here, otherwise it will rewrite the following settings!
        base.OnModelCreating(builder);

        // Custom application mappings
        builder.Entity<User>(entity =>
        {
            entity.Property(e => e.Email).HasMaxLength(450).IsRequired();
            entity.HasIndex(e => e.Email).IsUnique();
            entity.Property(e => e.Password).IsRequired();
        });

        builder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(450).IsRequired();
            entity.HasIndex(e => e.Name).IsUnique();
        });

        builder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RoleId });
            entity.HasIndex(e => e.UserId);
            entity.HasIndex(e => e.RoleId);
            entity.Property(e => e.UserId);
            entity.Property(e => e.RoleId);
            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles).HasForeignKey(d => d.RoleId);
            entity.HasOne(d => d.User).WithMany(p => p.UserRoles).HasForeignKey(d => d.UserId);
        });

        builder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Id);
            entity.HasOne(e => e.User).WithMany(t => t.Tables).HasForeignKey(e => e.UserID);
        });
        
        builder.Entity<TableField>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.Id);
            entity.HasOne(e => e.Table).WithMany(t => t.TableFields).HasForeignKey(e => e.TableID);
        });

        builder.Entity<Role>().HasData(
            new Role { Id = 1, Name = CustomRoles.User },
            new Role { Id = 2, Name = CustomRoles.Admin }
        );
    }
}
