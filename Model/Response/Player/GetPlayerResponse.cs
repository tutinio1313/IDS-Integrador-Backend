using IDS_Integrador.Model.Response;
using IDS_Integrador.Model.Entity.Team;

namespace IDS_Integrador.Model.Response.Player
{
    public class GetPlayerResponse : Response
    {
        private enum ErrorTypes
        {
            ThereIsNotPlayers = 1,
            GetSuccesfullyPlayers = 0
        }

        public List<IDS_Integrador.Model.Entity.Team.Player>? Players {get;set;}

        public void MessageHandler(int ErrorValue)
        {
            StateExecution = ErrorValue == 0;

            switch(ErrorValue)
            {
                case (int) ErrorTypes.ThereIsNotPlayers:
                Messages.Add("¡No hay jugadores cargados!");
                StateExecution = false;
                break;

                case (int) ErrorTypes.GetSuccesfullyPlayers:
                Messages.Add("Los jugadores se entregaron correctamente.");
                StateExecution = true;
                break;
            }
        }             
    }
}