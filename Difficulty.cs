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
    [Activity(Label = "Activity1")]
    public class Difficulty : Activity
    {
        Button btnEasy, btnMedium, btnHard;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout1);

            btnEasy = FindViewById<Button>(Resource.Id.button2);
            btnMedium = FindViewById<Button>(Resource.Id.button1);
            btnHard = FindViewById<Button>(Resource.Id.button3);

            btnEasy.Click += Easy;
            btnMedium.Click += Medium;
            btnHard.Click += Hard;
            // Create your application here
        }

        public void Easy(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(GameScreen));
            i.PutExtra("Difficulty", "easy");
            StartActivity(i);
        }

        public void Medium(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(GameScreen));
            i.PutExtra("Difficulty", "medium");
            StartActivity(i);
        }

        public void Hard(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(GameScreen));
            i.PutExtra("Difficulty", "hard");
            StartActivity(i);
        }
    }
}