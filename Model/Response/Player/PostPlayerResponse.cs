using IDS_Integrador.Model.Response;
using IDS_Integrador.Model.Entity.Team;

namespace IDS_Integrador.Model.Response.Player
{
    public class PostPlayerResponse : Response
    {
        private enum ErrorTypes
        {
            SuccesfullyUploadedPlayers = 0,
            ModelProblem = 1,
            PlayerIDWasLoadedPreviously = 2,
            CategoryNotFound = 3,
            TeamNotFound = 4,
            SomethingWentWrong = 5

        }
        
        public IDS_Integrador.Model.Entity.Team.Player? Player {get; set;}

        public void MessageHandler(int ErrorValue)
        {
            StateExecution = ErrorValue == 0;

            switch(ErrorValue)
            {
                case (int) ErrorTypes.SuccesfullyUploadedPlayers:
                Messages.Add("Los jugadores se entregaron correctamente.");
                StateExecution = true;
                break;

                case (int) ErrorTypes.ModelProblem:
                Messages.Add("Hay un problema en los datos ingresados");
                StateExecution = false;
                break;

                case (int) ErrorTypes.PlayerIDWasLoadedPreviously:
                Messages.Add("El DNI ya fue cargado previamente");
                break; 
                
                case (int) ErrorTypes.CategoryNotFound:
                Messages.Add("La categoria ingresada no fue encontrada");
                break;

                case (int) ErrorTypes.TeamNotFound:
                Messages.Add("El equipo no fue encontrado");
                break;

                case (int) ErrorTypes.SomethingWentWrong:
                Messages.Add("Algo salio mal en el servidor");
                break;

            }
        }             
    }
}