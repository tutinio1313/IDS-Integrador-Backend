using IDS_Integrador.Model.Response;

namespace IDS_Integrador.Model.Response.User
{
    public class UserRegisterResponse : Response
    {
        private enum ErrorTypes
        {
            ModelIsNotValid,
            TheEmailIsNotAvailable,
            TheUsernameIsNotAvailable,
            RegisteredSuccesful
        }

        public void MessageHandler(int ErrorValue)
        {
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

                default:
                Messages.Add("¡El usuario se ha registrado satisfactoriamente!");
                break;
            }
        }         
    }
}