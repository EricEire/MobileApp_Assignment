using Android.App;
using Android.Widget;
using Android.OS;

namespace MobileApp_Assignment
{
    [Activity(Label = "MobileApp_Assignment", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
        }
    }
}

