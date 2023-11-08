using IDS_Integrador.Model.Response;

namespace IDS_Integrador.Model.Response.User
{
    public class UserRegisterResponse : Response
    {
        public enum ErrorTypes
        {
            ModelIsNotValid,
            TheEmailIsNotAvailable,
            TheUsernameIsNotAvailable,
            RegisteredSuccesful,
            CantRegistered
        }

        public void MessageHandler(int ErrorValue)
        {
            StateExecution = ErrorValue == (int) UserRegisterResponse.ErrorTypes.RegisteredSuccesful;
            switch(ErrorValue)
            {
                case (int) ErrorTypes.ModelIsNotValid:
                Messages.Add("¡El payload no es compatible!");
                break;

                case (int) ErrorTypes.TheEmailIsNotAvailable:
                Messages.Add("¡El email ya se ha registrado previamente!");
                break;

                case (int) ErrorTypes.TheUsernameIsNotAvailable:
                Messages.Add("¡El usuario ya se ha registrado previamente!");
                break;

                case (int) ErrorTypes.RegisteredSuccesful:
                Messages.Add("¡El usuario se ha registrado satisfactoriamente!");
                break;

                case (int) ErrorTypes.CantRegistered:
                Messages.Add("¡No se pudo registrar!");
                break;

                default:
                Messages.Add("¡Ooops algo ha salido mal");
                break;
            }
        }         
    }
}