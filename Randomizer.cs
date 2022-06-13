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
        private Random rnd;
        private int index;
        public string[,] XMLExtractedData;
        public ImageView logo;
        public string[] imgPath;
        public int[] levelsCompleted = new int[8];

        public void SetLogo(string[,] par_XMLExtractedData, ImageView par_logo)
        {
            XMLExtractedData = par_XMLExtractedData;
            logo = par_logo;
        }

        private void GenerateRandomList()
        {
            rnd = new Random();
            for (int i = 0; i < levelsCompleted.Length; ++i)
            {
                int randomIndex = rnd.Next(levelsCompleted.Length);
                int temp = levelsCompleted[randomIndex];
                levelsCompleted[randomIndex] = levelsCompleted[i];
                levelsCompleted[i] = temp;
            }
            throw new NotImplementedException();
        }

        private string IterateRandomList()
        {
            int resourceId = (int)typeof(Resource.Drawable).GetField(XMLExtractedData[index, 2]).GetValue(null);
            logo.SetImageResource(resourceId);
            string logoName = XMLExtractedData[index, 1];
            index++;
            return logoName;
        }
    }
}