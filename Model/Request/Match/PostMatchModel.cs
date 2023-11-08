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
        public int IDHomeTeam {get;set;}

        [Required(ErrorMessage ="No has ingresado el equipo local.")]
        [DataType(DataType.Text)]
        public int IDVisitorTeam {get;set;}

        [Required(ErrorMessage = "No has ingresado la fecha y hora del partido.")]
        [DataType(DataType.DateTime)]
        public DateTime Date {get; set;}

        [Required(ErrorMessage = "No has ingresado la categoria.")]
        public int IDCategory {get; set;}
    }
}