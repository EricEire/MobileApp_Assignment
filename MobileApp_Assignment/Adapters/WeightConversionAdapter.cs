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
    class WeightConversionAdapter : BaseAdapter
    {

        Context Context;
        public double Weight { get; }

        public WeightConversionAdapter(double w,Context context)
        {
            Weight = w;
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
            WeightConversionAdapterViewHolder holder = null;

            if (view == null)
            {
                var inflater = Context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                view = inflater.Inflate(Resource.Layout.TempConversion, parent, false);


                var txtWeight = view.FindViewById<EditText>(Resource.Id.txtWeight);

                holder = new WeightConversionAdapterViewHolder(txtWeight);

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

    }

    class WeightConversionAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }

        public EditText Weight { get; }

        public WeightConversionAdapterViewHolder(EditText txtWeight)
        {
            txtWeight.Text = Weight.Text;
        }
    }
}