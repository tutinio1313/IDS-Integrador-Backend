using Microsoft.AspNetCore.Mvc;
using IDS_Integrador.Model.Entity.Team;
using IDS_Integrador.Database;
using IDS_Integrador.Model.Response.Team;
using IDS_Integrador.Model.Request.Team;


namespace IDS_Integrador.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {

        private readonly ILogger<TeamController> _logger;
        private readonly TeamContext context;
        public TeamController(ILogger<TeamController> logger, TeamContext context) {_logger = logger; this.context = context; }


        [HttpGet]
        public GetTeamsResponse GetTeams()
        {
            GetTeamsResponse response = new();
            
            if(context.Teams.Count() > 0)
            {
                response.Teams = context.Teams.ToList();
                response.StateExecution = true;
            }
            else
            {
                response.StateExecution = false;
                response.MessageHandler(0);                
            }
            return response;
        }

        [HttpPost]
        public async Task<PostTeamResponse> Post(TeamPostModel model)
        {
            PostTeamResponse response = new();

            if(ModelState.IsValid)
            {
                bool IsNameValid = String.IsNullOrEmpty(model.Name) && String.IsNullOrWhiteSpace(model.Name);
                bool IsUrlValid = String.IsNullOrEmpty(model.UrlImage) && String.IsNullOrWhiteSpace(model.UrlImage);

                if(IsNameValid && IsUrlValid)
                {
                    if(context.Teams.Where(x => x.Name.ToLower() == model.Name.ToLower()).Count() == 0)
                    {
                        Team team = new
                            (
                            context.Teams.Count(),
                            model.Name,
                            model.UrlImage
                            );
                            var AddResult = await context.Teams.AddAsync(team);

                            if(AddResult != null)
                            {
                                var SaveResult = context.SaveChangesAsync().IsCompletedSuccessfully;
                                if(SaveResult)
                                {
                                    response.MessageHandler(5);
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
                    if(IsNameValid) {response.MessageHandler(1);}
                    if(IsUrlValid) {response.MessageHandler(2);}
                }
            }
           
            return response;
        }

    }
}