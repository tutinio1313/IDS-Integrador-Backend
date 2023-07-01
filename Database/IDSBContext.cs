using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using IDS_Integrador.Model.Entity;

#pragma warning disable CS8618
namespace IDS_Integrador.Database
{
    public class IDSBContext : IdentityDbContext<User>
    {
        public IDSBContext(DbContextOptions options) : base(options){}    
        public DbSet<User> Users {get; set;}
        public DbSet<Role> Roles {get; set;}
    }
}