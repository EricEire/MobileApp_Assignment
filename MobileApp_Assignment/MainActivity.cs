using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Views;

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
            Window.RequestFeature(WindowFeatures.NoTitle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            btnConvertTemp= FindViewById<Button>(Resource.Id.btnConvertTemperature);
            btnConvertWeight = FindViewById<Button>(Resource.Id.btnConvertWeight);
            btnRecipes= FindViewById<Button>(Resource.Id.btnRecipes);


            btnConvertTemp.Click += BtnConvertTemp_Click;
            btnConvertWeight.Click += BtnConvertWeight_Click;
            btnRecipes.Click += BtnRecipes_Click;


        }

        private void BtnRecipes_Click(object sender, System.EventArgs e)
        {
            Intent RecipeIntent = new Intent(this, typeof(RecipeActivity));
            StartActivityForResult(RecipeIntent, 98);
        }

        private void BtnConvertWeight_Click(object sender, System.EventArgs e)
        {
            Intent WeightIntent = new Intent(this, typeof(WeightConversionActivity));
            StartActivityForResult(WeightIntent, 99);
        }

        private void BtnConvertTemp_Click(object sender, System.EventArgs e)
        {
            Intent TempIntent = new Intent(this, typeof(TemperatureActivity));
            StartActivityForResult(TempIntent, 100); 
        }
    }
}

