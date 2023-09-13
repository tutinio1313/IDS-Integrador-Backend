using IDS_Integrador.Model.Response;
using IDS_Integrador.Model.Entity.Team;

namespace IDS_Integrador.Model.Response.Category
{
    public class PostCategoryResponse : Response
    {
        private enum ErrorTypes
        {
            CategoryLoadedSuccesful = 0,
            TheNameIsNotCorrect = 1,
            TheCategoryWasLoadedPreviously = 2,
        }

        public IDS_Integrador.Model.Entity.Team.Category? Category {get;set;}

        public void MessageHandler(int ErrorValue)
        {
            StateExecution = ErrorValue == 0;

            switch(ErrorValue)
            {
                case (int) ErrorTypes.TheCategoryWasLoadedPreviously:
                Messages.Add("La categoria ya fue cargada.");
                break;

                case (int) ErrorTypes.TheNameIsNotCorrect:
                Messages.Add("El nombre no es correcto.");
                break;

                case (int) ErrorTypes.CategoryLoadedSuccesful:
                Messages.Add("La categoria se cargo correctamente.");
                break;
            }
        }             
    }
}