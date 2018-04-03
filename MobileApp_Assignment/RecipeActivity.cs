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

            LVrecipes.ItemClick += LVrecipes_ItemClick;
        }

        private void LVrecipes_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            int rowClicked = e.Position;

            FragmentTransaction txn = FragmentManager.BeginTransaction();
            var recipeData = new Bundle();
            recipeData.PutInt("RecipeID", rowClicked);
            recipeData.PutString("RecipeTitle", Recipes[rowClicked].RecipeTitle);
            recipeData.PutString("RecipeIngredients", Recipes[rowClicked].RecipeIngredients);
            recipeData.PutString("RecipeSteps", Recipes[rowClicked].RecipeSteps);
            RecipeDlgFrg recipeDlgFrg = new RecipeDlgFrg() { Arguments = recipeData };

            recipeDlgFrg.Show(txn,"Recipe");
        }

        private void FetchRecipes()
        {
            DBstore dbStore = new DBstore();

            IEnumerable<Recipe> recipes = dbStore.GetRecipes();

            Recipes = recipes.ToList();

        }
    }
}