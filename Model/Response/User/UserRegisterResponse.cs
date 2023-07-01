using IDS_Integrador.Model.Response;

namespace IDS_Integrador.Model.Response.User
{
    public class UserRegisterResponse : Response
    {
        private enum ErrorTypes
        {
            ModelIsNotValid,

        }

        public void MessageErrorHandler(int ErrorValue)
        {
            switch(ErrorValue)
            {
                case (int) ErrorTypes.ModelIsNotValid:
                Messages.Add("The payload is not compatible!");
                break;
            }
        }         
    }
}