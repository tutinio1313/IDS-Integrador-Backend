using IDS_Integrador.Model.Response;

namespace IDS_Integrador.Model.Response.User
{
    public class UserLoginResponse : Response
    {
        public enum ErrorTypes
        {
            LoginSuccessful = 1,
            ModelIsNotValid,
            TheEmailIsNotRegistered,
            TheUsernameIsNotRegistered,
            PasswordNotValid

        }

        public string? Token {get; set;} = string.Empty;

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
                Messages.Add("¡El usuario no esta registrado!");
                break;

                case (int) ErrorTypes.LoginSuccessful:
                Messages.Add("¡Se ha ingresado correctamente!");
                break;

                case (int) ErrorTypes.PasswordNotValid:
                Messages.Add("¡La contraseña ingresada no es correcta!");
                break;
            }
        }          
    }
}