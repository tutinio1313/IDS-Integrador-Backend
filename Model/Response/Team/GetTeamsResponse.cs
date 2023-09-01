using IDS_Integrador.Model.Response;
using IDS_Integrador.Model.Entity.Team;

namespace IDS_Integrador.Model.Response.Team
{
    public class GetTeamsResponse : Response
    {
        private enum ErrorTypes
        {
            ThereIsNotTeams,
            GetSuccesfullyTeam
        }

        public List<IDS_Integrador.Model.Entity.Team.Team>? Teams {get;set;}

        public void MessageHandler(int ErrorValue)
        {
            switch(ErrorValue)
            {
                case (int) ErrorTypes.ThereIsNotTeams:
                Messages.Add("¡No hay equipos cargados!");
                StateExecution = false;
                break;

                case (int) ErrorTypes.GetSuccesfullyTeam:
                Messages.Add("Los archivos se entregaron correctamente");
                StateExecution = true;
                break;
            }
        }          
    }
}