using IDS_Integrador.Model.Response;

namespace IDS_Integrador.Model.Response.User
{
    public class UserLoginResponse : Response
    {
        private enum ErrorTypes
        {
            LoginSuccessful = 1,
            ModelIsNotValid,
            TheEmailIsNotRegistered,
            TheUsernameIsNotRegistered

        }

        public string? JWT {get; set;} = string.Empty;

        public void MessageHandler(int ErrorValue)
        {
            StateExecution = ErrorValue == (int) ErrorTypes.LoginSuccessful;

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

                case (int) ErrorTypes.LoginSuccessful:
                Messages.Add("¡Se ha ingresado correctamente!");
                break;
            }
        }          
    }
}