using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Recipe_Saver.Data;
using Recipe_Saver.Models;
using Sentry;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recipe_Saver.Pages
{
<<<<<<< Updated upstream
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IRecipeData _recipeSaver;
        public IndexModel(ILogger<IndexModel> logger, IRecipeData recipeSaver)
        {
            _logger = logger;
            _recipeSaver = recipeSaver;
        }
        public List<RecipeList> Recipes { get; set; }
        public NewRecipe NewRecipe { get; set; }
        public async Task<ActionResult> OnGet()
        {
            Recipes = await _recipeSaver.GetRecipeList();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            try
            {
                _recipeSaver.AddRecipe(Request.Form["txtRecipeName"].ToString()
                    , Request.Form["txtRecipeLink"].ToString()
                    , Convert.ToDateTime(Request.Form["txtForWeekCommencing"]));
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        [HttpPost]
        public async Task<IActionResult> OnPostArchive(IFormCollection collection)
        {
            try
            {
                _recipeSaver.ArchiveRecipe(Convert.ToInt32(Request.Form["RecipeListID"]));
				return RedirectToPage("./Index", new { @redirect = "archive" });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
=======
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private readonly IRecipeData _recipeSaver;
		public IndexModel(ILogger<IndexModel> logger, IRecipeData recipeSaver)
		{
			_logger = logger;
			_recipeSaver = recipeSaver;
		}
		public List<RecipeList> Recipes { get; set; }
		public NewRecipe NewRecipe { get; set; }
		public async Task<ActionResult> OnGet()
		{
			try
			{
				Recipes = await _recipeSaver.GetRecipeList();
				return Page();
			}
			catch (Exception er)
			{
				SentrySdk.CaptureException(er);
				throw new Exception(er.ToString());
			}
		}
		public async Task<IActionResult> OnPost()
		{
			try
			{
				_recipeSaver.AddRecipe(Request.Form["txtRecipeName"].ToString()
						, Request.Form["txtRecipeLink"].ToString()
						, Convert.ToDateTime(Request.Form["txtForWeekCommencing"]));
				return RedirectToPage("./Index");
			}
			catch (Exception ex)
			{
				SentrySdk.CaptureException(ex);
				throw new Exception(ex.ToString());
			}
		}
	}
>>>>>>> Stashed changes
}
