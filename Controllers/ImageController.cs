using Microsoft.AspNetCore.Mvc;
using IDS_Integrador.Model.Request.Photo;
using IDS_Integrador.Database;
using IDS_Integrador.Model.Entity;
using IDS_Integrador.Model.Entity.Photo;
using IDS_Integrador.Model.Response;
using IDS_Integrador.Model.Response.Photo;

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IDS_Integrador.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        public ImageController(ILogger<ImageController> logger, TeamContext context) { _logger = logger; this.context = context; }

        private readonly ILogger<ImageController> _logger;
        private readonly TeamContext context;
        private const string ImagePath = "./Database/Image/";

        [HttpPost]
        [Route("/Img/Team")]
        public async Task<IResponse> PostTeamPhoto([FromBody]PostTeamPhotoRequest request)
        {
            PostTeamPhotoResponse response = new();
            if(ModelState.IsValid)
            {
                

            }
            return response;
        }

        [HttpPost]
        [Route("/Img/Player")]
        public async Task<IResponse> PostPlayerPhoto([FromBody]PostTeamPhotoRequest request)
        {
            PostTeamPhotoResponse response = new();
            if(ModelState.IsValid)
            {

            }
            return response;
        }
    }
}