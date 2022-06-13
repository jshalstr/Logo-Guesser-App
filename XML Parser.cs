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
using System.IO;
using System.Xml;
using Xamarin.Essentials;

namespace Logo_Guesser
{
    internal class ParserClass
    {
        string XMLFileName, TagName;
        Stream stream;
        XmlDocument localInfo_Xml;
        XmlNodeList tagList;
        string[,] XMLExtractedValues;
        int cnt;

        public ParserClass(string xmlfilename, string tagname)
        {
            this.XMLFileName = xmlfilename;
            this.TagName = tagname;
        }

        public async void ConnectXML()
        {
            try
            {
                stream = await FileSystem.OpenAppPackageFileAsync(XMLFileName);
                localInfo_Xml = new XmlDocument();
                localInfo_Xml.Load(stream);
                tagList = localInfo_Xml.GetElementsByTagName(TagName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public string[,] ExtractXMLData(string query_difficulty)
        {
            try
            {
                using (stream)
                {
                    int tagListCount = 0;
                    foreach (XmlElement xmlElement in tagList)
                    {
                        string difficulty = xmlElement.ChildNodes[0].InnerText;
                        string logoName = xmlElement.ChildNodes[1].InnerText;
                        string imgPath = xmlElement.ChildNodes[2].InnerText;

                        if (query_difficulty == difficulty)
                        {
                            tagListCount++;
                        }
                    }
                    XMLExtractedValues = new string[tagListCount, 3];
                    foreach (XmlElement xmlElement in tagList)
                    {
                        string difficulty = xmlElement.ChildNodes[0].InnerText;
                        string logoName = xmlElement.ChildNodes[1].InnerText;
                        string imgPath = xmlElement.ChildNodes[2].InnerText;

                        if (query_difficulty == difficulty)
                        {
                            XMLExtractedValues[cnt, 0] = difficulty;
                            XMLExtractedValues[cnt, 1] = logoName;
                            XMLExtractedValues[cnt, 2] = imgPath;
                            cnt++;
                        }
                    }
                }
                return XMLExtractedValues;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }





    }
}