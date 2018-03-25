using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

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

            Button btnTemp = FindViewById<Button>(Resource.Id.btnConvertTemp);

            btnTemp.Click += (object sender, System.EventArgs e) =>
        {
            Intent  = new Intent(this, typeof(CSharpKeywordsActivity));
            StartActivity(CSharpKeywordsIntent);
        }
    }
}

