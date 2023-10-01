using IDS_Integrador.Model.Entity.Team;
using IDS_Integrador.Database;
using Microsoft.EntityFrameworkCore;

namespace IDS_Integrador.Database.Test
{
    public static class PopulateDB
    {
        private static readonly Category[] categories = new Category[3] {
            new() {IdCategory = 1, Name = "Primera" },
            new() { IdCategory = 2, Name = "Reserva" },
            new() {IdCategory = 3, Name = "Novena" } };

        private static readonly Team[] teams = new Team[4] {
                new() {IDTeam = 1, Name = "Boca Juniors", UrlImage = "https://a.espncdn.com/combiner/i?img=/i/teamlogos/soccer/500/5.png"},
                new() {IDTeam = 2, Name = "River Plate", UrlImage = "https://a.espncdn.com/combiner/i?img=/i/teamlogos/soccer/500/16.png"},
                new() {IDTeam = 3, Name = "Colón", UrlImage = "https://a.espncdn.com/combiner/i?img=/i/teamlogos/soccer/500/7.png"},
                new() {IDTeam = 4, Name = "Unión", UrlImage = "https://a.espncdn.com/combiner/i?img=/i/teamlogos/soccer/500/20.png"}
                };

        private static readonly Player[] players = new Player[22] {
            new() {IDPlayer = 1, Dorsal = "1", Name = "Sergio", Lastname = "Romero", TeamID = teams[0].IDTeam, Birthday = new DateOnly(1987,2,22), CategoryID = categories[0].IdCategory},
            new() {IDPlayer = 2, Dorsal = "17", Name = "Luis", Lastname = "Advincula", TeamID = teams[0].IDTeam, Birthday = new DateOnly(1990,3,2), CategoryID = categories[0].IdCategory},
            new() {IDPlayer = 3, Dorsal = "4", Name = "Jorge", Lastname = "Figal", TeamID = teams[0].IDTeam, Birthday = new DateOnly(1994,4,3), CategoryID = categories[0].IdCategory},
            new() {IDPlayer = 4, Dorsal = "6", Name = "Marcos", Lastname = "Rojo", TeamID = teams[0].IDTeam, Birthday = new DateOnly(1990,3,20), CategoryID = categories[0].IdCategory},
            new() {IDPlayer = 5, Dorsal = "18", Name = "Frank", Lastname = "Fabra", TeamID = teams[0].IDTeam, Birthday = new DateOnly(1991,2,22), CategoryID = categories[0].IdCategory},
            new() {IDPlayer = 6, Dorsal = "36", Name = "Cristian", Lastname = "Medina", TeamID = teams[0].IDTeam, Birthday = new DateOnly(2002,6,1), CategoryID = categories[0].IdCategory},
            new() {IDPlayer = 7, Dorsal = "8", Name = "Guillermo", Lastname = "Fernandez", TeamID = teams[0].IDTeam, Birthday = new DateOnly(1991,10,1), CategoryID = categories[0].IdCategory},
            new() {IDPlayer = 8, Dorsal = "21", Name = "Ignacio", Lastname = "Fernandez", TeamID = teams[0].IDTeam, Birthday = new DateOnly(2002,7,25), CategoryID = categories[0].IdCategory},
            new() {IDPlayer = 9, Dorsal = "19", Name = "Valentín", Lastname = "Barco", TeamID = teams[0].IDTeam, Birthday = new DateOnly(2004,7,23), CategoryID = categories[0].IdCategory},
            new() {IDPlayer = 10, Dorsal = "16", Name = "Miguel", Lastname = "Merentiel", TeamID = teams[0].IDTeam, Birthday = new DateOnly(1996,2,24), CategoryID = categories[0].IdCategory},
            new() {IDPlayer = 11, Dorsal = "10", Name = "Edinson", Lastname = "Cavani", TeamID = teams[0].IDTeam, Birthday = new DateOnly(1987,2,14), CategoryID = categories[0].IdCategory},

            new() {IDPlayer = 12, Dorsal = "1", Name = "Franco", Lastname = "Armani", TeamID = teams[1].IDTeam, Birthday = new DateOnly(1986,10,16), CategoryID = categories[0].IdCategory},
            new() {IDPlayer = 13, Dorsal = "13", Name = "Enzo", Lastname = "Díaz", TeamID = teams[1].IDTeam, Birthday = new DateOnly(1987,2,14), CategoryID = categories[0].IdCategory},
            new() {IDPlayer = 14, Dorsal = "3", Name = "Ramiro", Lastname = "Funes Mori", TeamID = teams[1].IDTeam, Birthday = new DateOnly(year: 1991,3,5), CategoryID = categories[0].IdCategory},
            new() {IDPlayer = 15, Dorsal = "17", Name = "Paulo", Lastname = "Díaz", TeamID = teams[1].IDTeam, Birthday = new DateOnly(1994,8,25), CategoryID = categories[0].IdCategory},
            new() {IDPlayer = 16, Dorsal = "31", Name = "Santiago", Lastname = "Simón", TeamID = teams[1].IDTeam, Birthday = new DateOnly(2002,6,13), CategoryID = categories[0].IdCategory},
            new() {IDPlayer = 17, Dorsal = "21", Name = "Matías", Lastname = "Kranevitter", TeamID = teams[1].IDTeam, Birthday = new DateOnly(1993,5,21), CategoryID = categories[0].IdCategory},
            new() {IDPlayer = 18, Dorsal = "10", Name = "Ignacio", Lastname = "Fernandez", TeamID = teams[1].IDTeam, Birthday = new DateOnly(1990,1,12), CategoryID = categories[0].IdCategory},
            new() {IDPlayer = 19, Dorsal = "22", Name = "Ezequiel", Lastname = "Barco", TeamID = teams[1].IDTeam, Birthday = new DateOnly(1999,3,29), CategoryID = categories[0].IdCategory},
            new() {IDPlayer = 20, Dorsal = "26", Name = "José", Lastname = "Paradela", TeamID = teams[1].IDTeam, Birthday = new DateOnly(1998,12,15), CategoryID = categories[0].IdCategory},
            new() {IDPlayer = 21, Dorsal = "36", Name = "Pablo", Lastname = "Solari", TeamID = teams[1].IDTeam, Birthday = new DateOnly(2001,3,22), CategoryID = categories[0].IdCategory},
            new() {IDPlayer = 22, Dorsal = "25", Name = "Salómon", Lastname = "Rondón", TeamID = teams[1].IDTeam, Birthday = new DateOnly(1989,9,16), CategoryID = categories[0].IdCategory}
        };

        public static TeamContext context;
        public static async Task<bool> LoadCategories()
        {
            if (context != null)
            {
                int counter = 0;
                foreach (Category category in categories)
                {
                    bool canPost = !context.Categories.Any(x => x.Name == category.Name);

                    if (canPost)
                    {
                        await context.Categories.AddAsync(category);
                        counter++;
                    }
                }
                return counter > 0;
            }
            return false;
        }
        public static async Task<bool> LoadTeams()
        {

            if (context != null)
            {
                int counter = 0;
                foreach (Team team in teams)
                {
                    bool canPost = !context.Teams.Any(x => x.Name == team.Name);

                    if (canPost)
                    {
                        await context.Teams.AddAsync(team);
                        counter++;
                    }
                }
                return counter > 0;
            }
            return false;
        }
        public async static Task<bool> LoadPlayers()
        {
            if(context != null)
            {
                int counter = 0;

                foreach(Player player in players){
                    bool canPost = !context.Players.Any(x => x.IDPlayer == player.IDPlayer);

                    if(canPost){
                        await context.Players.AddAsync(player);
                        counter++;
                    }
                }

                return counter > 0;
            }
            return false;
        }
        public static void LoadMatches()
        {

        }

        public static void LoadContext(IApplicationBuilder application)
        {
            context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<TeamContext>();
        }

        public static async void SaveChangesAsync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}