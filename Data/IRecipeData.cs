using Recipe_Saver.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recipe_Saver.Data
{
	public interface IRecipeData
	{
		RecipeList RecipeList { get; set; }

		Task<int> AddRecipe(string RecipeName, string RecipeLink, string RecipeBook, string RecipePageNo);
		Task<int> ArchiveRecipe(int RecipeListID);
		Task<List<RecipeList>> GetRecipeList();
	}
}
