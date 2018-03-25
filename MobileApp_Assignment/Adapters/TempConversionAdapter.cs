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

namespace MobileApp_Assignment.Adapters
{
    class TempConversionAdapter : BaseAdapter
    {
        
        Context Context;
        public double temp { get; }
        RadioButton c, f;

        public TempConversionAdapter(double t,RadioButton c, RadioButton f,Context context)
        {
            temp = t;
            Context = context;
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
            TempConversionAdapterViewHolder holder = null;

           
            if (view == null)
            {
                var inflater = Context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                view = inflater.Inflate(Resource.Layout.TempConversion, parent, false);

                
                var txtTemperature = view.FindViewById<EditText>(Resource.Id.txtTemp);
                
                holder = new TempConversionAdapterViewHolder(txtTemperature);

                view.Tag = holder;
            }

            //holder = view.Tag as CSharpKeywordAdapterViewHolder;
            //holder.imgCSharpLogo.SetImageResource(Resource.Drawable.csharp);
            //holder.lblCSharpKeyword.Text = CSharpKeywords[position].Keyword;
            //holder.lblCSharpKeywordDefinition.Text = CSharpKeywords[position].Definition;

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

    }

    class TempConversionAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use

        public EditText Temp { get; }

        public TempConversionAdapterViewHolder(EditText txtTemperature)
        {
            txtTemperature.Text = Temp.Text;
        }
    }
}