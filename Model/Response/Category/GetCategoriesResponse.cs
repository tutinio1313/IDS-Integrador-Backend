using IDS_Integrador.Model.Response;
using IDS_Integrador.Model.Entity.Team;

namespace IDS_Integrador.Model.Response.Category
{
    public class GetCategoriesResponse : Response
    {
        private enum ErrorTypes
        {
            ThereIsNotCategories = 1,
            GetSuccesfullyCategories = 0
        }

        public List<IDS_Integrador.Model.Entity.Team.Category>? Categories {get;set;}

        public void MessageHandler(int ErrorValue)
        {
            StateExecution = ErrorValue == 0;

            switch(ErrorValue)
            {
                case (int) ErrorTypes.ThereIsNotCategories:
                Messages.Add("¡No hay categorias cargadas!");
                StateExecution = false;
                break;

                case (int) ErrorTypes.GetSuccesfullyCategories:
                Messages.Add("Los categorias se entregaron correctamente.");
                StateExecution = true;
                break;
            }
        }             
    }
}