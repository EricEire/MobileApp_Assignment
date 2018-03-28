using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MobileApp_Assignment
{
    [Activity(Label = "WeightConversionActivity")]
    public class WeightConversionActivity : Activity
    {

        EditText WeightTxt;
        TextView ConvertedWeightTxt;
        Button btnGoHome;
        Spinner spinner;
        ArrayAdapter adapter;
       


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.WeightConversion);

            WeightTxt = FindViewById<EditText>(Resource.Id.txtWeight);
            ConvertedWeightTxt = FindViewById<TextView>(Resource.Id.txtConvertedWeight);


            //Spinner for drop down menu to chose what conversion will be run on WeightTxt
            spinner = FindViewById<Spinner>(Resource.Id.spinner);

            spinner.ItemSelected += Spinner_ItemSelected;
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(Spinner_ItemSelected);
            adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.weight_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;


            
            btnGoHome = FindViewById<Button>(Resource.Id.btnHome);

            btnGoHome.Click += BtnGoHome_Click;
            
        }

        private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            int choice;
            double w;
            double conversion;
            

            choice = (e.Position);

            switch (choice)
            {
                //Grams to ounces
                case 0:
                    if (double.TryParse(WeightTxt.Text, out w))
                         {
                    conversion=  w / 28.34952;
                    ConvertedWeightTxt.Text = $"{conversion.ToString()} Ounces";
                    };
                    break;
                    

                //Ounces to grams
                case 1:
                    if (double.TryParse(WeightTxt.Text, out w))
                        {
                        conversion = w * 28.34952;
                        ConvertedWeightTxt.Text = $"{conversion.ToString()} Grams";
                        };
                    break;

                //Ml to fl Oz
                case 2:
                    if (double.TryParse(WeightTxt.Text, out w))
                    {
                        conversion = w * 0.0338;
                        ConvertedWeightTxt.Text = $"{conversion.ToString()} fluid Ounces";
                    };
                    break;

                //ml to cups
                case 3:
                    if (double.TryParse(WeightTxt.Text, out w))
                    {
                        conversion = w * 0.004227;
                        ConvertedWeightTxt.Text = $"{conversion.ToString()} cups";
                    };
                    break;

                    //fl oz to ml
                case 4:
                    if (double.TryParse(WeightTxt.Text, out w))
                    {
                        conversion = w * 29.573;
                        ConvertedWeightTxt.Text = $"{conversion.ToString()} Millilitres";
                    };
                    break;

                //fl oz to cups
                case 5:
                    if (double.TryParse(WeightTxt.Text, out w))
                    {
                        conversion = w * 0.12500;
                        ConvertedWeightTxt.Text = $"{conversion.ToString()} cups";
                    };
                    break;

                //cups to ml
                case 6:
                    if (double.TryParse(WeightTxt.Text, out w))
                    {
                        conversion = w / 0.0042268;
                        ConvertedWeightTxt.Text = $"{conversion.ToString()} Millilitres";
                    };
                    break;

                //Cups to fl Oz
                case 7:
                    if (double.TryParse(WeightTxt.Text, out w))
                    {
                        conversion = w / 8;
                        ConvertedWeightTxt.Text = $"{conversion.ToString()} Millilitres";
                    };
                    break;


            }



        }


        private void BtnGoHome_Click(object sender, EventArgs e)
        {
            Intent resetIntent = new Intent(this, typeof(MainActivity));
            StartActivityForResult(resetIntent, 100);
        }
    }
}