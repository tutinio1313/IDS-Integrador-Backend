using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace IDS_Integrador.Model.Request.User
{
    public class UserLoginKeyModel
    {
        [Required(ErrorMessage ="No has ingresado el token.")]
        public string Token {get;set;} = string.Empty;
    }
}