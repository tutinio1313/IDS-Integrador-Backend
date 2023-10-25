using IDS_Integrador.Model.Response;
using IDS_Integrador.Model.Response.Category;

namespace IDS_Integrador.Model.Response.Photo
{
    public class PostTeamPhotoResponse : Response
    {
        private enum ErrorTypes
        {
            PostTeamSuccesfull = 0,
            TeamNotFound = 1,
        }

        public string? URLPhoto {get; set;} = string.Empty;

        public void MessageHandler(int ErrorValue)
        {
            StateExecution = ErrorValue == (int) ErrorTypes.PostTeamSuccesfull;
            switch(ErrorValue)
            {
                case (int) ErrorTypes.PostTeamSuccesfull:
                Messages.Add("La foto se ha cargado correctamente.");
                break;

                case (int) ErrorTypes.TeamNotFound:
                Messages.Add("El equipo no se ha encontrado.");
                break;

                default:
                Messages.Add("Algo ha salido mal.");
                break;
            }
        }
    }    
}