using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace MobileApp_Assignment
{
    [Activity(Label = "MobileApp_Assignment", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button btnConvertTemp;
        Button btnConvertWeight;
        Button btnRecipes;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            btnConvertTemp= FindViewById<Button>(Resource.Id.btnConvertTemperature);
            btnConvertWeight = FindViewById<Button>(Resource.Id.btnConvertWeight);
            btnRecipes= FindViewById<Button>(Resource.Id.btnRecipes);


            btnConvertTemp.Click += BtnConvertTemp_Click;
            btnConvertWeight.Click += BtnConvertWeight_Click;


        }

        private void BtnConvertWeight_Click(object sender, System.EventArgs e)
        {
            Intent resetIntent = new Intent(this, typeof(WeightConversionActivity));
            StartActivityForResult(resetIntent, 99);
        }

        private void BtnConvertTemp_Click(object sender, System.EventArgs e)
        {
            Intent resetIntent = new Intent(this, typeof(TemperatureActivity));
            StartActivityForResult(resetIntent,100); 
        }
    }
}

