using IDS_Integrador.Model.Response;
using IDS_Integrador.Model.Entity.Team;

namespace IDS_Integrador.Model.Response.Team
{
    public class GetTeamsResponse : Response
    {
        private enum ErrorTypes
        {
            ThereIsNotTeams = 1,
            GetSuccesfullyTeam = 0
        }

        public List<IDS_Integrador.Model.Entity.Team.Team>? Teams {get;set;}

        public void MessageHandler(int ErrorValue)
        {
            SetStateExecution(ErrorValue);

            switch(ErrorValue)
            {
                case (int) ErrorTypes.ThereIsNotTeams:
                Messages.Add("¡No hay equipos cargados!");
                StateExecution = false;
                break;

                case (int) ErrorTypes.GetSuccesfullyTeam:
                Messages.Add("Los equipos se entregaron correctamente.");
                StateExecution = true;
                break;
            }
        }

        private void SetStateExecution(int value)
        {
            bool IsValueOnErrorRange = value.Equals(1);
            if(IsValueOnErrorRange)
            {
                StateExecution = false;
            }
            
            else
            {
                StateExecution = true;
            }
        }                
    }
}