using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using IDS_Integrador.Model.Entity;

#pragma warning disable CS8618
namespace IDS_Integrador.Database
{
    public class IDSBContext : IdentityDbContext<User>
    {
        public IDSBContext(DbContextOptions<IDSBContext> options) : base(options){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySql(ConnectionString,version);
        }

        private string ConnectionString = "Server=localhost;Database=ids;Uid=root;Pwd=tuti1313;SslMode=Preferred;";
        private MariaDbServerVersion version = new(new Version(10, 6, 12));
        public DbSet<User> Users {get; set;}
        public DbSet<Role> Roles {get; set;}
    }
}