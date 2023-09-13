using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace IDS_Integrador.Model.Request.Match
{
    public class PostMatchModel
    {
        [Required(ErrorMessage ="No has ingresado el equipo local.")]
        [DataType(DataType.Text)]
        public string IDHomeTeam {get;set;} = string.Empty;

        [Required(ErrorMessage ="No has ingresado el equipo local.")]
        [DataType(DataType.Text)]
        public string IDVisitorTeam {get;set;} = string.Empty;

        [Required(ErrorMessage = "No has ingresado la fecha y hora del partido.")]
        [DataType(DataType.DateTime)]
        public DateTime Date {get; set;}
    }
}