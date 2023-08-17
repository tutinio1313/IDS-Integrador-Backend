using IDS_Integrador.Model.Response;

namespace IDS_Integrador.Model.Response.User
{
    public class UserLoginTokenResponse : Response
    {
        private enum ErrorTypes
        {
            ModelIsNotValid,
            TheTokenIsNotValid,
            TheTokenIsExpired,

        }

        public void MessageHandler(int ErrorValue)
        {
            switch(ErrorValue)
            {
                case (int) ErrorTypes.ModelIsNotValid:
                Messages.Add("¡El payload no es compatible!");
                break;

                case (int) ErrorTypes.TheTokenIsNotValid:
                Messages.Add("¡El token no es valido!");
                break;

                case (int) ErrorTypes.TheTokenIsExpired:
                Messages.Add("¡El token ha expirado!");
                break;
            }
        }          
    }
}