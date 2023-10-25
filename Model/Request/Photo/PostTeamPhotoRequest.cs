using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDS_Integrador.Model.Request.Photo
{
    public class PostTeamPhotoRequest
    {
        [Required(ErrorMessage = "No se ha cargado el ID del equipo")]
        public int IDTeam {get;set;}
        [Required(ErrorMessage = "La foto no se ha cargado.")]        
        public string Photo {get;set;} = string.Empty;
    }
}