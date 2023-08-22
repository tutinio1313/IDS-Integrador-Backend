using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using IDS_Integrador.Model.Entity.Team;


#pragma warning disable CS8618
namespace IDS_Integrador.Database
{
    public class TeamContext : DbContext
    {
        public TeamContext(DbContextOptions<TeamContext> options) : base(options){}

        public DbSet<Team> Teams {get; set;}
        public DbSet<Category> Categories {get; set;}
        public DbSet<Player> Players {get; set;}
        public DbSet<Match> Matches {get; set;}
    }
}