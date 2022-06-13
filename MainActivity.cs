using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System;
using Android.Content;

namespace Logo_Guesser
{
    [Activity(Label = "Logo Guesser", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btnStart, btnExit;
    
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            btnStart = FindViewById<Button>(Resource.Id.button1);
            btnExit = FindViewById<Button>(Resource.Id.button2);

            btnStart.Click += btnStartOnClick;
            btnExit.Click += Exit;
        }
        public void btnStartOnClick(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(Difficulty));
            StartActivity(i);
        }

        public void Exit(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}