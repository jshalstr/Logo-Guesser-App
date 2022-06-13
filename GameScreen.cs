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
    [Activity(Label = "GameScreen")]
    public class GameScreen : Activity
    {
        Button btnEnter, btnExit;
        ImageView imgLogo;
        TextView txtLogo;
        EditText edt;
        string[,] ReturnedVal;
        string answer, entry;
        Randomizer logoRnd = new Randomizer();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GameScreen_Layout);

            btnExit = FindViewById<Button>(Resource.Id.button1);
            btnEnter = FindViewById<Button>(Resource.Id.button2);
            imgLogo = FindViewById<ImageView>(Resource.Id.imageView1);
            txtLogo = FindViewById<TextView>(Resource.Id.textView1);
            edt = FindViewById<EditText>(Resource.Id.editText1);

            ParserClass myparser = new ParserClass("GameInfo.xml", "level");
            myparser.ConnectXML();
            ReturnedVal = myparser.ExtractXMLData("easy");

            logoRnd.SetLogo(ReturnedVal, imgLogo);

            logoRnd.GenerateRandomList();
            answer = logoRnd.IterateRandomList();
            btnEnter.Click += btnStartOnClick;
        }

        public void btnStartOnClick(object sender, EventArgs e)
        {
            entry = edt.Text.ToUpper().Trim();

            if (answer == entry)
            {
                edt.Text = "";
                answer = logoRnd.IterateRandomList();
            }
            else
            {
                edt.Text = "";
                Toast.MakeText(Application.Context, $"{entry} is wrong", ToastLength.Short).Show();
            }
        }

    }
}