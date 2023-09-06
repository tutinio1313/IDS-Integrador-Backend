using IDS_Integrador.Model.Response;
using IDS_Integrador.Model.Entity.Team;

namespace IDS_Integrador.Model.Response.Team
{
    public class PostTeamResponse : Response
    {
        private enum ErrorTypes
        {
            TeamPostedSuccesfully = 0,
            TheNameIsNotValid = 1,
            TheURLIsNotValid = 2,
            TheTeamAlreadyExists = 3,
            SomethingWentWrong = 4,
            
            

        }

        public IDS_Integrador.Model.Entity.Team.Team? Team {get;set;}

        public void MessageHandler(int value)
        {
            SetStateExecution(value);
            
            switch(value)
            {
                case (int) ErrorTypes.TeamPostedSuccesfully:
                Messages.Add("¡Se ha guardado correctamente!");
                break;
                case (int) ErrorTypes.TheNameIsNotValid:
                Messages.Add("¡El nombre no es valido!");
                break;
                case (int) ErrorTypes.TheURLIsNotValid:
                Messages.Add("¡La URL de la imagen no es valida!");
                break;
                case (int) ErrorTypes.TheTeamAlreadyExists:
                Messages.Add("¡El equipo que se ingresó ya existe!");
                break;
                case (int) ErrorTypes.SomethingWentWrong:
                Messages.Add("¡Algo salio mal guardando el equipo!");
                break;
            }
        }    

        private void SetStateExecution(int value)
        {
            bool IsValueSuccesfull = value.Equals(0);
            if(IsValueSuccesfull)
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