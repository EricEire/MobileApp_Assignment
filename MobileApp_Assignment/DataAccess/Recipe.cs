using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace MobileApp_Assignment.DataAccess
{
    [Table("Recipe")]
    class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int RecipeID { get; set; }

        public string RecipeTitle{ get; set; }

        public string RecipeDescription { get; set; }

        public string RecipeIngredients { get; set; }

        public string RecipeSteps { get; set; }

        public Recipe() { }

        
    }
}