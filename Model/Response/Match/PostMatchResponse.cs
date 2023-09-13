using IDS_Integrador.Model.Response;
using IDS_Integrador.Model.Entity.Team;

namespace IDS_Integrador.Model.Response.Match
{
    public class PostMatchResponse : Response
    {
        private enum ErrorTypes
        {
            PostSuccesfully = 0,
            ThereIsNotMatches = 1,
            TeamsAreTheSame = 2,
            TheMatchWasUploadedPreviously = 3
        }

        public IDS_Integrador.Model.Entity.Team.Match? Match {get;set;}

        public void MessageHandler(int ErrorValue)
        {
            StateExecution = ErrorValue == 0;

            switch(ErrorValue)
            {
                case (int) ErrorTypes.ThereIsNotMatches:
                Messages.Add("Los datos ingresados son erroneos.");
                break;

                case (int) ErrorTypes.PostSuccesfully:
                Messages.Add("Se cargó correctamente el partido.");
                break;

                case (int) ErrorTypes.TeamsAreTheSame:
                Messages.Add("El equipo local y el equipo visitante es el mismo.");
                break;

                case (int) ErrorTypes.TheMatchWasUploadedPreviously:
                Messages.Add("El partido ya se ha cargado previamente");
                break;
            }
        }             
    }
}