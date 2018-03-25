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


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

         
        }
    }
}