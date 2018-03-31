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
using MobileApp_Assignment.DataAccess;
using MobileApp_Assignment.Adapters;

namespace MobileApp_Assignment
{
    [Activity(Label = "RecipeActivity")]
    public class RecipeActivity : Activity
    {
        List<Recipe> Recipes = new List<Recipe>();
        ListView LVrecipes;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.RecipeLV);
            LVrecipes = FindViewById<ListView>(Resource.Id.lvRecipes);

            FetchRecipes();

            LVrecipes.Adapter = new RecipeAdapter(this, Recipes);

        }

        private void FetchRecipes()
        {
            DBstore.InitDB();
        }
    }
}