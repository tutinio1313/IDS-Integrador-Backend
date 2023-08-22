using IDS_Integrador.Model.Response;
using IDS_Integrador.Model.Entity.Team;

namespace IDS_Integrador.Model.Response.Team
{
    public class GetTeamsResponse : Response
    {
        private enum ErrorTypes
        {
            ThereIsNotTeams,
            

        }

        public List<IDS_Integrador.Model.Entity.Team.Team>? Teams {get;set;}

        public void MessageHandler(int ErrorValue)
        {
            switch(ErrorValue)
            {
                case (int) ErrorTypes.ThereIsNotTeams:
                Messages.Add("¡No hay equipos cargados!");
                break;
            }
        }          
    }
}