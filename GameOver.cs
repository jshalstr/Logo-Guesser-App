using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logo_Guesser
{
    [Activity(Label = "GameOver")]
    public class GameOver : Activity
    {
        Button btnRestart;
        TextView txtResult;
        string total;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.gameOver);

            btnRestart = FindViewById<Button>(Resource.Id.button1);
            txtResult = FindViewById<TextView>(Resource.Id.textView1);

            total = Intent.GetStringExtra("Score");

            txtResult.Text = $"Your score is {total}";
            btnRestart.Click += Restart;


        }

        public void Restart(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(MainActivity));
            StartActivity(i);
        }
    }
}