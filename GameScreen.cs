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
using System.Timers;

namespace Logo_Guesser
{
    [Activity(Label = "GameScreen")]
    public class GameScreen : Activity
    {
        Button btnEnter, btnExit;
        ImageView imgLogo;
        EditText edt;
        string[,] ReturnedVal;
        int[] RandomList;
        string answer, entry, difficulty;
        Randomizer logoRnd = new Randomizer();
        ParserClass myparser;
        Timer timer;
        int cnt = 30;
        TextView txt;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GameScreen_Layout);

            btnExit = FindViewById<Button>(Resource.Id.button1);
            btnEnter = FindViewById<Button>(Resource.Id.button2);
            imgLogo = FindViewById<ImageView>(Resource.Id.imageView1);
            edt = FindViewById<EditText>(Resource.Id.editText1);
            txt = FindViewById<TextView>(Resource.Id.textView1);

            difficulty = Intent.GetStringExtra("Difficulty");

            ParserClass myparser = new ParserClass("GameInfo.xml", "level");
            myparser.ConnectXML();
            ReturnedVal = myparser.ExtractXMLData($"{difficulty}");

            logoRnd.SetLogo(ReturnedVal, imgLogo);
            RandomList = logoRnd.GenerateRandomList();
            answer = logoRnd.IterateRandomList();

            txt.Text = $"{cnt}";
            StartTime();

            btnExit.Click += btnExitOnClick;
            btnEnter.Click += btnStartOnClick;
        }

        public void btnExitOnClick(object sender, EventArgs e)
        {
            //SaveGame();
            Intent i = new Intent(this, typeof(MainActivity));
            StartActivity(i);
        }


        public void btnStartOnClick(object sender, EventArgs e)
        {
            entry = edt.Text.ToUpper().Trim();

            if (answer == entry)
            {
                timer.Stop();
                cnt = 30;
                edt.Text = "";
                answer = logoRnd.IterateRandomList();
                StartTime();
            }
            else
            {
                edt.Text = "";
                Toast.MakeText(Application.Context, $"{entry} is wrong", ToastLength.Short).Show();
            }
        }

        public void StartTime()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += timerElapsed;
            timer.Start();
        }
        public void timerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (cnt == 0)
            {
                timer.Stop();
            }
            else
            {
                cnt -= 1;
                txt.Text = $"{cnt}";
            }
        }


        //public void SaveGame()
        //{
        //    ParserClass ToXML = new ParserClass("GameInfo.xml", "player");
        //    ToXML.ConnectXML();
        //    ToXML.SaveGameToXML(difficulty, RandomList, index);
        //}

    }
}