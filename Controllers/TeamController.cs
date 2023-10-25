using Microsoft.AspNetCore.Mvc;
using IDS_Integrador.Model.Entity.Team;
using IDS_Integrador.Database;
using IDS_Integrador.Model.Response.Team;
using IDS_Integrador.Model.Request.Team;
using Microsoft.AspNetCore.Authorization;
using System.Text;

namespace IDS_Integrador.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {

        private readonly ILogger<TeamController> _logger;
        private readonly TeamContext context;
        public TeamController(ILogger<TeamController> logger, TeamContext context) { _logger = logger; this.context = context; }


        [HttpGet]
        public GetTeamsResponse GetTeams()
        {
            GetTeamsResponse response = new();

            if (context.Teams.Any())
            {
                response.Teams = context.Teams.ToList();
                response.MessageHandler(0);
            }
            else
            {
                response.MessageHandler(1);
            }
            return response;
        }

        [HttpPost]
        public async Task<PostTeamResponse> Post([FromBody] TeamPostModel model)
        {
            PostTeamResponse response = new();
            if (ModelState.IsValid)
            {
                bool IsNameValid = !String.IsNullOrEmpty(model.Name);
                bool IsUrlValid = !String.IsNullOrEmpty(model.UrlImage);

                if (IsNameValid && IsUrlValid)
                {
                    bool IsTheTeamNotLoaded = !context.Teams.Where(x => x.Name.ToLower() == model.Name.ToLower()).Any();                    
                    if (IsTheTeamNotLoaded)
                    {
                        Team team = new()
                        {
                            IDTeam = context.Teams.Count() + 1,
                            Name = model.Name,
                            UrlImage = model.UrlImage
                        };
                        var AddResult = await context.Teams.AddAsync(team);

                        if (AddResult != null)
                        {
                            var SaveResult = context.SaveChangesAsync().IsCompletedSuccessfully;
                            if (SaveResult)
                            {
                                response.MessageHandler(0);
                            }
                            else
                            {
                                response.MessageHandler(4);
                            }
                        }
                        else
                        {
                            response.MessageHandler(4);
                        }
                    }
                    else
                    {
                        response.MessageHandler(3);
                    }
                }
                else
                {
                    if (!IsNameValid) { response.MessageHandler(1); }
                    if (!IsUrlValid) { response.MessageHandler(2); }
                }
            }
            return response;
        }

    }
}