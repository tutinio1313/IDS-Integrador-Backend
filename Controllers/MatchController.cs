using Microsoft.AspNetCore.Mvc;
using IDS_Integrador.Model.Entity.Team;
using IDS_Integrador.Database;
using IDS_Integrador.Model.Response.Match;
using IDS_Integrador.Model.Request.Match;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace IDS_Integrador.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchController : ControllerBase
    {

        private readonly ILogger<MatchController> _logger;
        private readonly TeamContext context;
        public MatchController(ILogger<MatchController> logger, TeamContext context) { _logger = logger; this.context = context; }


        [HttpGet]
        public GetMatchResponse Get()
        {
            GetMatchResponse response = new();

            if (context.Matches.Any())
            {
                response.Matches = context.Matches.ToList();
                response.MessageHandler(0);
            }
            else
            {
                response.MessageHandler(1);
            }
            return response;
        }

        [HttpPost]
        public async Task<PostMatchResponse> Post([FromBody]PostMatchModel model)
        {
            PostMatchResponse response = new();
            if (ModelState.IsValid)
            {
                if (ModelIsValid(model))
                {
                    bool TeamsAreDifferent = model.IDHomeTeam != model.IDVisitorTeam;
                    if (TeamsAreDifferent)
                    {
                        Team HomeTeam = context.Teams.First(x => x.IDTeam == model.IDHomeTeam);
                        Team VisitorTeam = context.Teams.First(x => x.IDTeam == model.IDVisitorTeam);
                        Category category = context.Categories.First(x => x.IdCategory == model.IDCategory);

                        bool CanPost = FoundMatches(HomeTeam, VisitorTeam, model.Date,category);


                        if (CanPost)
                        {
                            Match match = new()
                            {
                                IDMatch = context.Matches.Count() + 1,
                                LocalTeamID = HomeTeam.IDTeam,
                                VisitorTeamID = VisitorTeam.IDTeam,
                                Date = model.Date,
                                category = category
                            };

                            await context.Matches.AddAsync(match);
                            await context.SaveChangesAsync();
                            response.MessageHandler(0);
                            response.Match = match;
                        }
                        else
                        {
                            response.MessageHandler(3);
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

        private bool ModelIsValid(PostMatchModel model) => !(
                                                             model.IDHomeTeam.Equals(0)
                                                          && model.IDVisitorTeam.Equals(0)
                                                          && model.Date < DateTime.Now
                                                            );

        private bool FoundMatches(Team Home, Team Visitor, DateTime Date, Category category)
        {
            List<Match> Matches = context.Matches.Where(x => x.LocalTeamID == Home.IDTeam).ToList();
            Matches = Matches.Where(x => x.VisitorTeamID == Visitor.IDTeam).ToList();
            Matches = Matches.Where(x => x.Date == Date).ToList();
            Matches = Matches.Where(x => x.category == category).ToList();

            return Matches.Any();
        }

    }
}