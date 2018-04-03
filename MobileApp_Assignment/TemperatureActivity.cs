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
        Button btnGoHome;
        EditText TempTxt;
        TextView TempConversion;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(WindowFeatures.NoTitle);

            SetContentView(Resource.Layout.TempConversion);

            TempTxt = FindViewById<EditText>(Resource.Id.txtTemp);
            TempConversion = FindViewById<TextView>(Resource.Id.txtConvertedTemp);
            Celcius = FindViewById<RadioButton>(Resource.Id.rbtnCel);
            Fahrenheit = FindViewById<RadioButton>(Resource.Id.rbtnFah);
            ConvertT = FindViewById<Button>(Resource.Id.btnConvertTemp);
            btnGoHome = FindViewById<Button>(Resource.Id.btnHome);



            ConvertT.Click += ConvertT_Click;
            btnGoHome.Click += BtnGoHome_Click;


        }

        private void BtnGoHome_Click(object sender, EventArgs e)
        {
            Intent resetIntent = new Intent(this, typeof(MainActivity));
            StartActivityForResult(resetIntent, 100);
        }

        private void ConvertT_Click(object sender, EventArgs e)
        {
            if (double.TryParse(TempTxt.Text, out double TemperatureInput))
            {
                if (Celcius.Checked)
                { 

                Temperature = (TemperatureInput - 32) * 5 / 9;

                TemperatureOutput = Temperature.ToString("n2");

                TempConversion.Text = $"{TemperatureOutput} C";

                 }
                if (Fahrenheit.Checked)            
            {
                Temperature = TemperatureInput * 9 / 5 + 32;

                TemperatureOutput = Temperature.ToString("n2");

                TempConversion.Text = $"{TemperatureOutput} F";

            }
            }
            else 
            {
                Toast toastMsg = Toast.MakeText(this,
                                            $"Error! " +
                                            $"{TempTxt.Text} is not a valid value. Please try again.",
                                            ToastLength.Long);
                toastMsg.Show();
            }

         }//end convertT
    }//end class
 }// end namespace