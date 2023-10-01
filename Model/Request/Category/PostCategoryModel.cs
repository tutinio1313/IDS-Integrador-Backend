using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace IDS_Integrador.Model.Request.Category
{
    public class PostCategoryModel
    {
        [Required(ErrorMessage ="No has ingresado el nombre del equipo.")]
        [DataType(DataType.Text)]
        public string name {get;set;} = string.Empty;
    }
}