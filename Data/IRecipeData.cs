﻿using Recipe_Saver.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recipe_Saver.Data
{
    public interface IRecipeData
    {
        RecipeList RecipeList { get; set; }

        Task<int> AddRecipe(string RecipeName, string RecipeLink, DateTime ForWeekCommencing);
        Task<List<RecipeList>> GetRecipeList();
    }
}