using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MobileApp_Assignment.DataAccess;

namespace MobileApp_Assignment
{

    public class RecipeDlgFrg : DialogFragment
    {
        TextView Title;
        TextView Ingredients;
        TextView Steps;
        //List<Recipe> Recipes = new List<Recipe>();

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            base.OnCreateView(inflater, container, savedInstanceState);

            var RecipeDlgFrgView = inflater.Inflate(Resource.Layout.RecipeDlgFrg, container, false);

            Title = RecipeDlgFrgView.FindViewById<TextView>(Resource.Id.lblTitle);
            Title.Text = Arguments.GetString("RecipeTitle");

            Ingredients = RecipeDlgFrgView.FindViewById<TextView>(Resource.Id.lblIngredients);
            Ingredients.Text = Arguments.GetString("RecipeIngredients");

            Steps = RecipeDlgFrgView.FindViewById<TextView>(Resource.Id.lblSteps);
            Steps.Text = Arguments.GetString("RecipeSteps");


            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            return RecipeDlgFrgView;
        }
    }
}