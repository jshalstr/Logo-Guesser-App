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
        public int[] RandomList = Enumerable.Range(0, 8).ToArray();

        public void SetLogo(string[,] par_XMLExtractedData, ImageView par_logo)
        {
            XMLExtractedData = par_XMLExtractedData;
            logo = par_logo;
        }

        public void GenerateRandomList()
        {
            rnd = new Random();
            for (int i = 0; i < RandomList.Length; i++)
            {
                int randomIndex = rnd.Next(RandomList.Length);
                int temp = RandomList[randomIndex];
                RandomList[randomIndex] = RandomList[i];
                RandomList[i] = temp;
            }
        }

        public string IterateRandomList()
        {
            int resourceId = (int)typeof(Resource.Drawable).GetField(XMLExtractedData[RandomList[index], 2]).GetValue(null);
            logo.SetImageResource(resourceId);
            string logoName = XMLExtractedData[RandomList[index], 1];
            index++;
            return logoName;
        }
    }
}