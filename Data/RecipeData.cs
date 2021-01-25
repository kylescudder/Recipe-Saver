using Dapper;
using Microsoft.Extensions.Configuration;
using Recipe_Saver.Db;
using Recipe_Saver.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe_Saver.Data
{
    public class RecipeData : IRecipeData
    {
        private readonly ISqlDb _dataAccess;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        public RecipeData(ISqlDb dataAccess
            //, IHttpContextAccessor httpContextAccessor
            )
        {
            _dataAccess = dataAccess;
            //_httpContextAccessor = httpContextAccessor;
        }
        public RecipeList RecipeList { get; set; }
        public async Task<List<RecipeList>> GetRecipeList()
        {
            var recs = await _dataAccess.LoadData<RecipeList, dynamic>("scud97_kssu.spGetRecipeList",
                                                              new { },
                                                              "Default");
            return recs;
        }
        public Task<int> AddRecipe(string RecipeName, string RecipeLink, DateTime ForWeekCommencing)
        {
            return _dataAccess.SaveData("scud97_kssu.spAddRecipe",
                                        new
                                        {
                                            RecipeName,
                                            RecipeLink,
                                            ForWeekCommencing
                                        },
                                        "Default");
        }
    }
}
