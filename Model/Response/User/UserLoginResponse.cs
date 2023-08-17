using IDS_Integrador.Model.Response;

namespace IDS_Integrador.Model.Response.User
{
    public class UserLoginResponse : Response
    {
        private enum ErrorTypes
        {
            ModelIsNotValid,
            TheEmailIsNotRegistered,
            TheUsernameIsNotRegistered

        }

        public void MessageHandler(int ErrorValue)
        {
            switch(ErrorValue)
            {
                case (int) ErrorTypes.ModelIsNotValid:
                Messages.Add("¡El payload no es compatible!");
                break;

                case (int) ErrorTypes.TheEmailIsNotRegistered:
                Messages.Add("¡El email no esta registrado!");
                break;

                case (int) ErrorTypes.TheUsernameIsNotRegistered:
                Messages.Add("¡El payload no esta registrado!");
                break;
            }
        }          
    }
}