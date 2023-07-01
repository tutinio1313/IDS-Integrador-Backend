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
        [Route("*/Login?key:{key}")]
        public Task<UserLoginResponse> LoginThroughKey(UserLoginModel model)
        {
            UserLoginResponse response = new();

            if(ModelState.IsValid)
            {
                response = UserService.Login(model);
            }
            else
            {
            response.StateExecution = false;
            response.MessageErrorHandler(0);
            }
            

            return Task.FromResult(response);
        }

        [HttpPost]
        public Task<UserRegisterResponse> Register(UserRegisterModel model)
        {
        UserRegisterResponse response = new();
            if(ModelState.IsValid)
            {
                response = UserService.Register(model);
            }
            else
            {
                response.StateExecution = false;
                response.MessageErrorHandler(0);
            }
            return Task.FromResult(response);
        }
    }
}