using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe_Saver.Models
{
    public class RecipeList
    {
        [Key]
        public int RecipeListID { get; set; }
        public string RecipeName { get; set; }
        public string RecipeLink { get; set; }
        public bool BookOrLink { get; set; }
    }
    public class NewRecipe
    {
        public string RecipeName { get; set; }
        public string RecipeLink { get; set; }
        public string RecipeBook { get; set; }
        public int RecipePageNo { get; set; }
    }
}
