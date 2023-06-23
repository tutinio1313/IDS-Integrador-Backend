using IDS_Integrador.Model.Response.User;
using IDS_Integrador.Model.Request.User;

namespace IDS_Integrador.Service
{
    public static class UserService
    {
        public static Task<UserLoginResponse> Login(UserLoginModel model)
        {
            UserLoginResponse response = new();

            return Task.FromResult(response);
        }  
        
    }
}