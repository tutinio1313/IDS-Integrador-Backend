
using Microsoft.AspNetCore.Identity;

namespace IDS_Integrador.Model.Entity
{
    public class User : IdentityUser
    {
        public string Name {get; set;} = String.Empty;
        public string Lastname {get; set;} = String.Empty;
    }
}
