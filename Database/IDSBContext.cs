using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using IDS_Integrador.Model.Entity;

#pragma warning disable CS8618
namespace IDS_Integrador
{
    public class dbContext : IdentityDbContext<IdentityUser>
    {
        public dbContext(DbContextOptions options) : base(options){}    
        public DbSet<User> Empleados {get; set;}
        public DbSet<IdentityRole> Roles {get; set;}
    }
}