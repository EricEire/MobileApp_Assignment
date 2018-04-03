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

        Context context;
        public List<Recipe> Recipes { get; }

        public RecipeAdapter(Context context, List<Recipe> Recipes)
        {
            this.context = context;
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
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                view = inflater.Inflate(Resource.Layout.RecipeRow, parent, false);

                var Img = view.FindViewById<ImageView>(Resource.Id.imgRecipe);
                var lblRecipeTitle = view.FindViewById<TextView>(Resource.Id.lblRecipeTitle);
                var lblRecipeDesc = view.FindViewById<TextView>(Resource.Id.lblRecipeDescription);
                
                holder = new RecipeAdapterViewHolder(Img, lblRecipeTitle, lblRecipeDesc);

                view.Tag = holder;
            }

            holder = view.Tag as RecipeAdapterViewHolder;
            holder.img.SetImageResource(Resource.Drawable.Cupcake1);
            holder.lblRecipeTitle.Text = Recipes[position].RecipeTitle;
            holder.lblRecipeDescription.Text = Recipes[position].RecipeDescription;

            return view;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return Recipes.Count;
            }
        }

        public override Recipe this[int position]
        {
            get
            {
                return Recipes[position];
            }
        }

    }

    class RecipeAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
        public ImageView img { get; set; }
        public TextView lblRecipeTitle { get; set; }
        public TextView lblRecipeDescription { get; set; }

        public RecipeAdapterViewHolder(ImageView img, TextView lblRecipeTitle, TextView lblRecipeDescription)
        {
            this.img = img;
            this.lblRecipeTitle = lblRecipeTitle;
            this.lblRecipeDescription = lblRecipeDescription;
        }
    }
}