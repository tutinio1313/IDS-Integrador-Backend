using IDS_Integrador.Model.Response.User;

namespace IDS_Integrador.Service
{
    public static class UserService
    {
        public static Task<UserLoginResponse> Login()
        {
            UserLoginResponse response = new();

            return Task.FromResult(response);
        }  
        
    }
}