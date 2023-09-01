using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

using IDS_Integrador.Database;
using IDS_Integrador.Model.Entity;
using IDS_Integrador.Model.Response.User;
using IDS_Integrador.Model.Request.User;
using Microsoft.EntityFrameworkCore;

namespace IDS_Integrador.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private UserManager<User> UserManager;
        private SignInManager<User> SignInManager;
        public UserController(ILogger<UserController> logger, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _logger = logger;
            UserManager = userManager;
            SignInManager = signInManager;
        }

        [HttpPost]
        [Route("/User/Login")]
        public async Task<UserLoginResponse> Login(UserLoginModel model)
        {
            UserLoginResponse response = new();

            if (ModelState.IsValid)
            {
                User? user = await UserManager.FindByNameAsync(model.Username);

                if(user != null)
                {
                    var result = await SignInManager.PasswordSignInAsync(user,model.Password,false,false);
                    if(result.Succeeded)
                    {
                        response.MessageHandler(3);
                        response.JWT = await SignInManager.UserManager.GenerateUserTokenAsync(user,"abc","auth"); 
                    }
                }

                else
                {
                    response.MessageHandler(2);
                }
            }
            else
            {
                HttpContext.Response.StatusCode = 422;
                response.MessageHandler(0);
            }


            return response;
        }
        [HttpPost]
        [Route("/User/LoginKey")]
        public async Task<UserLoginResponse> LoginThroughKey(UserLoginKeyModel model)
        {
            UserLoginResponse response = new();


            if (ModelState.IsValid)
            {
                

                if (response.Messages.Count is not 0)
                {

                }

                else
                {
                    HttpContext.Response.StatusCode = 200;
                    response.StateExecution = true;

                }
            }
            else
            {
                HttpContext.Response.StatusCode = 422;
                response.StateExecution = false;
                response.MessageHandler(0);
            }



            return response;
        }

        [HttpPost]
        [Route("/User/Register")]
        public async Task<UserRegisterResponse> Register(UserRegisterModel model)
        {
            UserRegisterResponse response = new();
            if (ModelState.IsValid)
            {

                User? IsEmailAvailable = await UserManager.FindByEmailAsync(model.Email);;
                User? IsUsernameAvailable = await UserManager.FindByNameAsync(model.Username);

                if (IsEmailAvailable == null && IsUsernameAvailable == null)
                {
                    User user = new();

                    user.UserName = model.Username;
                    user.Email = model.Email;
                    user.Name = model.Name;
                    user.Lastname = model.Lastname;


                    IdentityResult result = await UserManager.CreateAsync(user, model.Password);

                    if(result.Succeeded)
                    {
                        response.StateExecution = true;
                        response.MessageHandler(5);
                    }

                }
                else
                {
                    response.StateExecution = false;

                    if (IsEmailAvailable != null)
                    {
                        response.MessageHandler(1);
                    }
                    if (IsUsernameAvailable != null)
                    {
                        response.MessageHandler(2);
                    }
                }
            }
            else
            {
                HttpContext.Response.StatusCode = 422;
                response.StateExecution = false;
                response.MessageHandler(0);
            }
            return response;
        }
    }
}