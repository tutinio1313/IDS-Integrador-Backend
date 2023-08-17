using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace IDS_Integrador.Model.Request.User
{
    public class UserLoginModel
    {
        [Required(ErrorMessage ="No has ingresado el usuario.")]
        public string Username {get;set;} = string.Empty;

        [Required(ErrorMessage ="No has ingresado la contraseña.")]
        public string Password {get;set;} = string.Empty;
                
    }
}