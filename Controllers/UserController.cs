using Microsoft.AspNetCore.Mvc;
using IDS_Integrador.Model.Entity;
using IDS_Integrador.Model.Response.User;
using IDS_Integrador.Service;
using IDS_Integrador.Model.Request.User;


namespace IDS_Integrador.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger) {_logger = logger;}


        [HttpPost]
        [Route("*/Login/{key}")]
        public Task<UserLoginResponse> Login(UserLoginModel model)
        {
            if(ModelState.IsValid)
            {
                 return UserService.Login(model);
            }
            UserLoginResponse response = new();

            response.MessageErrorHandler();

            return Task.FromResult(response);
        }


    }
}