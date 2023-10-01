using Microsoft.AspNetCore.Mvc;
using IDS_Integrador.Model.Entity.Team;
using IDS_Integrador.Database;
using IDS_Integrador.Model.Response.Category;
using IDS_Integrador.Model.Request.Category;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace IDS_Integrador.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {

        private readonly ILogger<CategoryController> _logger;
        private readonly TeamContext context;
        public CategoryController(ILogger<CategoryController> logger, TeamContext context) { _logger = logger; this.context = context; }


        [HttpGet]
        public GetCategoriesResponse GetCategories()
        {
            GetCategoriesResponse response = new();

            if (context.Categories.Any())
            {
                response.Categories = context.Categories.ToList();
                response.MessageHandler(0);
            }
            else
            {
                response.MessageHandler(1);
            }
            return response;
        }

        [HttpPost]
        public async Task<PostCategoryResponse> Post(PostCategoryModel model)
        {
            PostCategoryResponse response = new();
            if (ModelState.IsValid)
            {
                if(!model.name.IsNullOrEmpty())
                {
                    bool WasCategoryLoadedPreviously = context.Categories.Any(x => x.Name == model.name);

                    if(!WasCategoryLoadedPreviously)
                    {
                        Category category = new()
                        {
                            Name = model.name,
                            IdCategory = context.Categories.Count() + 1
                        };

                        await context.Categories.AddAsync(category);
                        context.SaveChanges();

                        response.MessageHandler(0);                        
                    }
                    else
                    {
                        response.MessageHandler(2);
                    }
                }
                else{
                    response.MessageHandler(1);
                }             
            }
            return response;
        }
    }
}