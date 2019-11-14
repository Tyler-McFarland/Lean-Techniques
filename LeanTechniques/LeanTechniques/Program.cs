using System;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;

namespace LeanTechniques
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonPictureData = null;

   
            string errMsg = "wrong";
            string albumID = null;

            //loops until a valid entry is selected
            while (errMsg != null)
            {
                Console.Write("Enter Album ID: ");
                albumID = Console.ReadLine();
                
                errMsg = validateEntry(albumID);

                if (errMsg != null)
                {
                    Console.WriteLine(errMsg + Environment.NewLine);
                }
            }

            //retrieve input from the web service using validated album id
            using (var web = new WebClient())
            {
                String url = "https://jsonplaceholder.typicode.com/photos?albumId=" + albumID;
                jsonPictureData = web.DownloadString(url);
            }

            //create a dynamic json Object using newtonsoft then loop through results and output
            dynamic jsonObj = JValue.Parse(jsonPictureData);
            foreach (var item in jsonObj)
            {
                string buildString = "[" + item.id.ToString() + "] " + item.title.ToString() + Environment.NewLine;
                Console.WriteLine(buildString);
            }
            //just stops the program from instantly closing the console
            Console.ReadLine();
        }
    
    

        //validates the id for blank, non numeric data, and valid range of albums.  The method also returns a dynamic error message.
        public static string validateEntry(string albumID)
        {
            string returnString = null;
            bool numeric = true;

            if (albumID.Trim().Equals(""))
            {
                returnString = "No Entry, please try again";
            }
            else
            {

                string[] numbers = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                for (int i = 0; i < albumID.Length; i++)
                {
                    string ID = albumID[i].ToString();
                    if (!(numbers.Contains(ID)))
                    {
                        returnString = "Non Numeric data, please try again";
                        numeric = false;
                        break;
                    }
                }
                if (numeric == true)
                {
                    int checkRange = int.Parse(albumID);
                    if (checkRange > 100 || checkRange <= 0)
                    {
                        returnString = "Album not within range, please try again";
                    }
                }
            }
            return returnString;
        }
    }
}
