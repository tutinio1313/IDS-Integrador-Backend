using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace IDS_Integrador.Model.Request.Player
{
    public class PlayerPostModel
    {
        [Required(ErrorMessage ="No has ingresado el DNI del jugador.")]
        public int ID {get;set;}
        [Required(ErrorMessage ="No has ingresado el nombre del jugador.")]
        [DataType(DataType.Text)]
        public string Name {get;set;} = string.Empty;
        [Required(ErrorMessage ="No has ingresado el nombre del jugador.")]
        [DataType(DataType.Text)]
        public string Dorsal {get;set;} = string.Empty;

        [Required(ErrorMessage ="No has ingresado el apellido del jugador.")]
        [DataType(DataType.Text)]
        public string Lastname {get; set;} = string.Empty;
        [Required(ErrorMessage = "No has ingresado la fecha de nacimiento del jugador.")]
        [DataType(DataType.Date)]
        public DateOnly Birthday { get; set;}

        [Required(ErrorMessage = "No has ingresado el club del jugador.")]
        [DataType(DataType.Text)]
        public int IDTeam { get; set;}

        [Required(ErrorMessage = "No has ingresado la categoria del jugador.")]
        [DataType(DataType.Text)]
        public int IDCategory {get; set;}
    }
}