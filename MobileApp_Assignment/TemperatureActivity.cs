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

namespace MobileApp_Assignment
{
    [Activity(Label = "TemperatureActivity")]
    public class TemperatureActivity : Activity
    {
        double Temperature;
        RadioButton Celcius, Fahrenheit;
        Button ConvertT;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.TempConversion);

            //FindViewById<RadioButton>(Resource.Id.rbtnCel).Selected = Celcius;

            //FindViewById<Button>(Resource.Id.btnConvertTemp).Click += btnConvertTemp_Clicked;
          



        }

        //private void btnConvertTemp_Clicked(object sender, EventArgs e)
        //{
        //    if()
        
        //}
    }
}