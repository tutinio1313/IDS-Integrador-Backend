using IDS_Integrador.Model.Response;
using IDS_Integrador.Model.Entity.Team;

namespace IDS_Integrador.Model.Response.Team
{
    public class PostTeamResponse : Response
    {
        private enum ErrorTypes
        {
            TheNameIsNotValid,
            TheURLIsNotValid,
            TheTeamAlreadyExists,
            SomethingWentWrong,
            TeamPostedSuccesfully
            

        }

        public IDS_Integrador.Model.Entity.Team.Team? Team {get;set;}

        public void MessageHandler(int value)
        {
            SetStateExecution(value);
            
            switch(value)
            {
                case (int) ErrorTypes.TheNameIsNotValid:
                Messages.Add("¡El nombre no es valido!");
                break;
                case (int) ErrorTypes.TheURLIsNotValid:
                Messages.Add("¡La URL de la imagen no es valida!");
                break;
                case (int) ErrorTypes.TheTeamAlreadyExists:
                Messages.Add("¡El equipo que se ingresó ya existe!");
                break;

            }
        }    

        private void SetStateExecution(int value)
        {
            bool IsValueOnErrorRange = value >= 0 && value < 4;
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