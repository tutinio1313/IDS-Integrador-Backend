using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IDS_Integrador.Model.Request.User
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage ="No has ingresado el usuario")]
        public string Username {get;set;} = string.Empty;

        [Required(ErrorMessage ="No has ingresado el nombre")]
        public string Name {get;set;} = string.Empty;
        [Required(ErrorMessage ="No has ingresado el usuario")]
        public string Lastname {get;set;} = string.Empty;

        [Required(ErrorMessage ="No has ingresado el email.")]
        [DataType(DataType.EmailAddress,ErrorMessage ="El email ingresado es incorrecto.")]
        public string Email {get;set;} = string.Empty;

        [Required(ErrorMessage ="No has ingresado la contraseña.")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
        [DataType(DataType.Password,ErrorMessage ="La contraseña ingresada es incorrecta.")]
        public string Password {get; set;} = string.Empty;
    }
}