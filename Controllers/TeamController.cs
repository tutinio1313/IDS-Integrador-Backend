using Microsoft.AspNetCore.Mvc;
using IDS_Integrador.Model.Entity;
using IDS_Integrador.Model.Response.User;
using IDS_Integrador.Model.Request.User;


namespace IDS_Integrador.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {

        private readonly ILogger<TeamController> _logger;
        public TeamController(ILogger<TeamController> logger) {_logger = logger;}

    }
}