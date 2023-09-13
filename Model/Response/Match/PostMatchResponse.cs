using IDS_Integrador.Model.Response;
using IDS_Integrador.Model.Entity.Team;

namespace IDS_Integrador.Model.Response.Match
{
    public class PostMatchResponse : Response
    {
        private enum ErrorTypes
        {
            ThereIsNotMatches = 1,
            GetSuccesfullyMatches = 0
        }

        public IDS_Integrador.Model.Entity.Team.Match? Match {get;set;}

        public void MessageHandler(int ErrorValue)
        {
            StateExecution = ErrorValue == 0;

            switch(ErrorValue)
            {
                case (int) ErrorTypes.ThereIsNotMatches:
                Messages.Add("¡No hay partidos cargados!");
                StateExecution = false;
                break;

                case (int) ErrorTypes.GetSuccesfullyMatches:
                Messages.Add("Los partidos se entregaron correctamente.");
                StateExecution = true;
                break;
            }
        }             
    }
}