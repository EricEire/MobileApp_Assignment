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
    class Temperature
    {
        public double Temp { get; set; }

        public Temperature(double t)
        {
            Temp = t;
        }
    }
}