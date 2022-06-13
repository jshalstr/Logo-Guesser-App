using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System;

namespace Logo_Guesser
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btnStart;
        ImageView imgLogo;
        TextView txtLogo;
        string[,] ReturnedVal;
        Randomizer logoRnd = new Randomizer();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            btnStart = FindViewById<Button>(Resource.Id.button1);
            imgLogo = FindViewById<ImageView>(Resource.Id.imageView1);
            txtLogo = FindViewById<TextView>(Resource.Id.textView1);

            ParserClass myparser = new ParserClass("GameInfo.xml", "level");
            myparser.ConnectXML();
            ReturnedVal = myparser.ExtractXMLData("easy");

            logoRnd.SetLogo(ReturnedVal, imgLogo);
            logoRnd.GenerateRandomList();

            btnStart.Click += btnStartOnClick;
        }
        public void btnStartOnClick(object sender, EventArgs e)
        {
            txtLogo.Text = logoRnd.IterateRandomList();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}