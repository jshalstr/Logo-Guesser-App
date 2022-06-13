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
    class Randomizer
    {
        private int interval;
        private Timer timer;
        private Random rnd;
        private int index;
        public string[,] XMLExtractedData;
        public ImageView logo;
        public string[] logoName;
        public string[] imgPath;

        public void SetLogo(string[,] par_XMLExtractedData)
        {
            XMLExtractedData = par_XMLExtractedData;
        }

        private void SelectRandomLogo(object sender, System.Timers.ElapsedEventArgs e)
        {
            rnd = new Random();
            index = rnd.Next(XMLExtractedData.GetLength(0));
            int resourceId = (int)typeof(Resource.Drawable).GetField(XMLExtractedData[index, 2]).GetValue(null);
            logo.SetImageResource(resourceId);

            throw new NotImplementedException();
        }
    }
}