using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using IDS_Integrador.Database;
using IDS_Integrador.Model.Entity;
using IDS_Integrador.Model.Response.User;
using IDS_Integrador.Model.Request.User;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace IDS_Integrador.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private const string key = "817c7a98281fcf4b90a23ce14ea5059f";
        private readonly SignInManager<User> SignInManager;
        private readonly UserManager<User> UserManager;
        private readonly RoleManager<Role> RoleManager;
        public UserController(ILogger<UserController> logger, UserManager<User> UserManager, SignInManager<User> SignInManager, RoleManager<Role> RoleManager)
        {
            _logger = logger;
            this.UserManager = UserManager;
            this.SignInManager = SignInManager;
            this.RoleManager = RoleManager;
        }

        private async Task<string> GenerateWebToken(User User) {
         JwtSecurityTokenHandler TokenHandler = new();
            byte[] Key = System.Text.Encoding.ASCII.GetBytes("Tm8gZ29vZCBmb3IgdGhpcyBodW1hbml0eQ==");
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new(ClaimTypes.Name, User.Id)
                    //,new(ClaimTypes.Role, Role.Name)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature)
            };
        SecurityToken Token = TokenHandler.CreateToken(tokenDescriptor);
        User.TokenAccess = TokenHandler.WriteToken(Token);
        return User.TokenAccess;
        }


        [HttpPost]
        [Route("/User/Login")]
        public async Task<UserLoginResponse> Login([FromBody]UserLoginModel model)
        {
            UserLoginResponse response = new();

            if (ModelState.IsValid)
            {
                User? user = await UserManager.FindByNameAsync(model.Username);

                if (user != null)
                {
                    var result = await SignInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        response.MessageHandler((int) UserLoginResponse.ErrorTypes.LoginSuccessful);
                        response.Token = await GenerateWebToken(user);
                    }
                    else
                    {
                        response.MessageHandler((int) UserLoginResponse.ErrorTypes.PasswordNotValid);
                    }
                }

                else
                {
                    response.MessageHandler((int) UserLoginResponse.ErrorTypes.TheUsernameIsNotRegistered);
                }
            }
            else
            {
                HttpContext.Response.StatusCode = 422;
                response.MessageHandler((int) UserLoginResponse.ErrorTypes.ModelIsNotValid);
            }


            return response;
        }
        [HttpPost]
        [Route("/User/LoginKey")]
        public async Task<UserLoginResponse> LoginThroughKey([FromBody]UserLoginKeyModel model)
        {
            UserLoginResponse response = new();


            if (ModelState.IsValid)
            {            
                
            }
            else
            {
                HttpContext.Response.StatusCode = 422;
                response.MessageHandler(0);
            }



            return response;
        }

        [HttpPost]
        [Route("/User/Register")]
        public async Task<UserRegisterResponse> Register([FromBody]UserRegisterModel model)
        {
            UserRegisterResponse response = new();
            if (ModelState.IsValid)
            {
                User? Email = await UserManager.FindByEmailAsync(model.Email); ;
                User? UserName = await UserManager.FindByNameAsync(model.Username);

                if (Email == null && UserName == null)
                {
                    User user = new();

                    user.UserName = model.Username;
                    user.Email = model.Email;
                    user.Name = model.Name;
                    user.Lastname = model.Lastname;

                    try{

                    IdentityResult result = await UserManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        response.MessageHandler((int) UserRegisterResponse.ErrorTypes.RegisteredSuccesful);
                    }
                    else
                    {
                        response.MessageHandler((int) UserRegisterResponse.ErrorTypes.CantRegistered);
                    }
                    }
                    catch (System.Exception)
                    {
                        
                        throw;
                    }
                

                }
                else
                {
                    if (Email == null)
                    {
                        response.MessageHandler((int) UserRegisterResponse.ErrorTypes.TheEmailIsNotAvailable);
                    }
                    if (UserName == null)
                    {
                        response.MessageHandler((int) UserRegisterResponse.ErrorTypes.TheUsernameIsNotAvailable);
                    }
                }
            }
            else
            {
                HttpContext.Response.StatusCode = 422;
                response.MessageHandler((int) UserRegisterResponse.ErrorTypes.ModelIsNotValid);
            }
            return response;
        }
    }
}