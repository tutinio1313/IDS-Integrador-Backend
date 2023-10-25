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
        private readonly string ConnectionString = "Server=localhost;Database=ids;Uid=root;Pwd=tuti1313;SslMode=Preferred;";
        private readonly MariaDbServerVersion version = new(new Version(10, 6, 12));
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySql(ConnectionString,version);
        }

        #pragma warning disable

        public DbSet<User> Users {get; set;}
        public DbSet<Role> Roles {get; set;}
    }
}