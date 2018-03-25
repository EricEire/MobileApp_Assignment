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
        string TemperatureOutput;
        RadioButton Celcius, Fahrenheit;
        Button ConvertT;
        EditText TempTxt;
        TextView TempConversion;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.TempConversion);

            TempTxt = FindViewById<EditText>(Resource.Id.txtTemp);
            TempConversion = FindViewById<TextView>(Resource.Id.txtConvertedTemp);
            Celcius = FindViewById<RadioButton>(Resource.Id.rbtnCel);
            Fahrenheit = FindViewById<RadioButton>(Resource.Id.rbtnFah);
            ConvertT = FindViewById<Button>(Resource.Id.btnConvertTemp);



            ConvertT.Click += ConvertT_Click;


        }

        private void ConvertT_Click(object sender, EventArgs e)
        {
        //    if (Celcius.)
        //    {
                if (double.TryParse(TempTxt.Text, out double TemperatureF))
                {
                    Temperature = (TemperatureF - 32) * 5 / 9;

                    TemperatureOutput = Temperature.ToString();

                    TempConversion.Text = $"{TemperatureOutput} C";
                    TempTxt.Text = "";
                }
                else
                {
                    Toast toastMsg = Toast.MakeText(this,
                                                $"Error--{TempTxt.Text} is not a valid value. Please try again.",
                                                ToastLength.Long);
                    toastMsg.Show();
                }
            //}//end celcius conversion

            //if (Fahrenheit.Selected)
            //{
            //    if (double.TryParse(TempTxt.Text, out double TemperatureC))
            //    {
            //        Temperature = TemperatureC * 9 / 5 + 32;

            //        TemperatureOutput = Temperature.ToString();

            //        TempConversion.Text = $"{TemperatureOutput} F";
            //        TempTxt.Text = "";
            //    }
            //    else
            //    {
            //        Toast toastMsg = Toast.MakeText(this,
            //                                    $"Error--{TempTxt.Text} is not a valid value. Please try again.",
            //                                    ToastLength.Long);
            //        toastMsg.Show();
            //    }
            //}


           

        }
    }
}