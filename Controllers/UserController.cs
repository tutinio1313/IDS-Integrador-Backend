using Microsoft.AspNetCore.Mvc;
using IDS_Integrador.Model.Entity;
using IDS_Integrador.Model.Response.User;
using IDS_Integrador.Service;


namespace IDS_Integrador.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger) {_logger = logger;}


        [HttpPost]
        [Route("*/Login/")]
        public Task<UserLoginResponse> Login()
        {
            return UserService.Login();
        }


    }
}