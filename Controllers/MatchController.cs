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
        public GetMatchResponse GetTeams()
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
        public async Task<PostMatchResponse> Post(PostMatchModel model)
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


                        bool CanPost = FoundMatches(HomeTeam, VisitorTeam, model.Date);


                        if (CanPost)
                        {
                            Match match = new()
                            {
                                IDMatch = (context.Matches.Count() + 1).ToString(),
                                LocalTeam = HomeTeam,
                                VisitTeam = VisitorTeam,
                                Date = model.Date
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
                                                             model.IDHomeTeam.IsNullOrEmpty()
                                                          && model.IDVisitorTeam.IsNullOrEmpty()
                                                          && model.Date < DateTime.Now
                                                            );

        private bool FoundMatches(Team Home, Team Visitor, DateTime Date)
        {
            List<Match> Matches = context.Matches.Where(x => x.LocalTeam == Home).ToList();
            Matches = Matches.Where(x => x.VisitTeam == Visitor).ToList();
            Matches = Matches.Where(x => x.Date == Date).ToList();

            return Matches.Count == 0;
        }

    }
}