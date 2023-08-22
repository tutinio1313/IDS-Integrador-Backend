using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace IDS_Integrador.Model.Request.Team
{
    public class TeamPostModel
    {
        [Required(ErrorMessage ="No has ingresado el nombre del equipo.")]
        [DataType(DataType.Text)]
        public string Name {get;set;} = string.Empty;

        [Required(ErrorMessage ="")]
        [DataType(DataType.Text)]
        public string UrlImage {get; set;} = string.Empty;
    }
}