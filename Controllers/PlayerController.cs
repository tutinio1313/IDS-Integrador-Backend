using Microsoft.AspNetCore.Mvc;
using IDS_Integrador.Model.Entity.Team;
using IDS_Integrador.Database;
using IDS_Integrador.Model.Response.Player;
using IDS_Integrador.Model.Request.Player;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace IDS_Integrador.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {

        private readonly ILogger<PlayerController> _logger;
        private readonly TeamContext context;
        public PlayerController(ILogger<PlayerController> logger, TeamContext context) { _logger = logger; this.context = context; }


        [HttpGet]
        public GetPlayerResponse GetTeams()
        {
            GetPlayerResponse response = new();

            if (context.Players.Any())
            {
                response.Players = context.Players.ToList();
                response.MessageHandler(0);
            }
            else
            {
                response.MessageHandler(1);
            }
            return response;
        }

        [HttpPost]
        public async Task<PostPlayerResponse> Post([FromBody] PlayerPostModel model)
        {
            PostPlayerResponse response = new();
            if (ModelState.IsValid)
            {
                if (ModelIsValid(model))
                {
                    bool IsThePlayerNotLoaded = !context.Teams.Where(x => x.Name.ToLower() == model.Name.ToLower()).Any();
                    if (IsThePlayerNotLoaded)
                    {
                        Category category = context.Categories.First(x => x.IdCategory == model.IDCategory);
                        Team team = context.Teams.First(x => x.IDTeam == model.IDTeam);

                        if (category != null && team != null)
                        {
                            bool IsDorsalAvailable = !context.Players.Where(x => x.TeamID == model.IDTeam).Where(x => x.Dorsal == model.Dorsal).Any();
                            if (IsDorsalAvailable)
                            {

                                Player player = new()
                                {
                                    IDPlayer = model.ID,
                                    Birthday = model.Birthday,
                                    Dorsal = model.Dorsal,
                                    Name = model.Name,
                                    Lastname = model.Lastname,
                                    CategoryID = category.IdCategory,
                                    TeamID = team.IDTeam
                                };



                                var AddResult = await context.Players.AddAsync(player);

                                if (AddResult != null)
                                {
                                    await context.SaveChangesAsync();
                                    response.MessageHandler(0);
                                    response.Player = player;


                                }
                                else
                                {
                                    response.MessageHandler(5);
                                }
                            }
                            else{
                                response.MessageHandler(6);
                            }
                        }
                        else
                        {
                            if (category == null) { response.MessageHandler(3); }
                            if (team == null) { response.MessageHandler(4); }

                        }
                    }
                    else
                    {
                        response.MessageHandler(2);
                    }
                }
                else
                {
                    response.MessageHandler(1);
                }
            }
            return response;
        }

        private bool ModelIsValid(PlayerPostModel model) => !(
                                                             model.Name.IsNullOrEmpty()
                                                          && model.Lastname.IsNullOrEmpty()
                                                          && model.IDCategory.Equals(0)
                                                          && model.IDTeam.Equals(0)
                                                            );

    }
}