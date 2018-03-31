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

namespace MobileApp_Assignment.Adapters
{
    class RecipeAdapter : BaseAdapter<Recipe>
    {

        Context Context;
        List<Recipe> Recipes = new List<Recipe>();

        public RecipeAdapter(Context context, List<Recipe> Recipes)
        {
            Context = context;
            this.Recipes = Recipes;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
      

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            RecipeAdapterViewHolder holder = null;

            if (view == null)
            {
                var inflater = Context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                view = inflater.Inflate(Resource.Layout.RecipeRow, parent, false);

                var Img = view.FindViewById<ImageView>(Resource.Id.imgRecipe);
                var lblRecipeTitle = view.FindViewById<TextView>(Resource.Id.lblRecipeTitle);
                var lblRecipeDesc = view.FindViewById<TextView>(Resource.Id.lblRecipeDescription);
                //var lblRecipeSteps = view.FindViewById<TextView>(Resource.Id.lblRecipeSteps);
                holder = new RecipeAdapterViewHolder(Img, lblRecipeTitle, lblRecipeDesc);

                view.Tag = holder;
            }

            //fill in your items
            //holder.Title.Text = "new text here";

            return view;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return 0;
            }
        }

        public override Recipe this[int position] => throw new NotImplementedException();
    }

    class RecipeAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
        private ImageView img;
        private TextView lblRecipeTitle;
        private TextView lblRecipeDescription;

        public RecipeAdapterViewHolder(ImageView img, TextView lblRecipeTitle, TextView lblRecipeDescription)
        {
            this.img = img;
            this.lblRecipeTitle = lblRecipeTitle;
            this.lblRecipeDescription = lblRecipeDescription;
        }
    }
}